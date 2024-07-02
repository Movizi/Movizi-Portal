using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movizi_Portal.Models;
using Movizi_Portal.Models.ViewModels;
using Movizi_Portal.Repository.IRepository;

namespace Movizi_Portal.Controllers
{
	public class ProjectController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public ProjectController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}

		public IActionResult Index()
		{
			List<Project> projects = _unitOfWork.Project.GetAll().ToList();
			return View(projects);
		}

		public IActionResult Upsert(int? id)
		{
			ProjectVM projectVM = new()
			{
				Project = new Project(),
				ProjectService = new ProjectService(),
				CarouselImage = new CarouselImage(),
				SelectedServices = [],
				IndustryList = _unitOfWork.Industry.GetAll().Select(industry => new SelectListItem
				{
					Text = industry.Name,
					Value = industry.Id.ToString()
				}),
				ServiceList = _unitOfWork.Service.GetAll().Select(service => new SelectListItem
				{
					Text = service.Name,
					Value = service.Id.ToString()
				}),
				CarouselImageList = _unitOfWork.CarouselImage.GetAll(u => u.ProjectId == id).ToList(),
			};

			if (id == null || id == 0)
			{
				// Create
				return View(projectVM);
			}
			else
			{
				// Edit
				projectVM.Project = _unitOfWork.Project.Get(x => x.Id == id);
				projectVM.ProjectService = _unitOfWork.ProjectService.Get(x => x.ProjectId == id);
				projectVM.CarouselImage = _unitOfWork.CarouselImage.Get(x => x.ProjectId == id);
				return View(projectVM);
			}
		}

		[HttpPost]
		public IActionResult Upsert(
			ProjectVM projectVM,
			IFormFile? mainImage,
			IFormFile? fontImage,
			IFormFile? colorsImage,
			List<IFormFile>? carouselImages)
		{
			if (ModelState.IsValid)
			{
				// Project
				if (projectVM.Project.Id == 0)
				{
					// Create
					projectVM.ProjectService = new ProjectService();
					projectVM.CarouselImage = new CarouselImage();

					// Project Service
					if (projectVM.SelectedServices.Count > 0)
					{
						foreach (var selectedService in projectVM.SelectedServices)
						{
							projectVM.ProjectService.Id = Guid.NewGuid();
							projectVM.ProjectService.ProjectId = projectVM.Project.Id;
							projectVM.ProjectService.Project = projectVM.Project;
							projectVM.ProjectService.ServiceId = selectedService;
							projectVM.ProjectService.Service = _unitOfWork.Service.Get(x => x.Id == selectedService);
						}
					}

					_unitOfWork.Project.Add(projectVM.Project);
					_unitOfWork.ProjectService.Add(projectVM.ProjectService);
					_unitOfWork.Save();
				}
				else
				{
					// Edit
					_unitOfWork.Project.Update(projectVM.Project);
					_unitOfWork.ProjectService.Update(projectVM.ProjectService);
				}

				// Images
				UpsertImage(mainImage, projectVM, "ImageUrl");
				UpsertImage(fontImage, projectVM, "ColorsImageUrl");
				UpsertImage(colorsImage, projectVM, "FontImageUrl");
				UpsertImages(carouselImages, projectVM);

				return RedirectToAction("Index");
			}
			else
			{
				projectVM.IndustryList = _unitOfWork.Industry.GetAll().Select(industry => new SelectListItem
				{
					Text = industry.Name,
					Value = industry.Id.ToString()
				});
				projectVM.ServiceList = _unitOfWork.Service.GetAll().Select(service => new SelectListItem
				{
					Text = service.Name,
					Value = service.Id.ToString()
				});
				return View(projectVM);
			}
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Project projectFromDb = _unitOfWork.Project.Get(x => x.Id == id);

			if (projectFromDb == null)
			{
				return NotFound();
			}

			return View(projectFromDb);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
			string wwwRootPath = _webHostEnvironment.WebRootPath;

			Project project = _unitOfWork.Project.Get(x => x.Id == id);
			List<CarouselImage> carouselImages = _unitOfWork.CarouselImage.GetAll(x => x.ProjectId == id).ToList();

			if (project == null)
			{
				return NotFound();
			}

			string imageUrl = project.ImageUrl;
			string colorsImageUrl = project.ColorsImageUrl;
			string fontsImageUrl = project.FontImageUrl;

			string[] urls = new string[] { imageUrl, colorsImageUrl, fontsImageUrl };

			foreach (var url in urls)
			{
				if (!string.IsNullOrEmpty(url))
				{
					string trimmedUrl = url.TrimStart('/', '\\');
					string path = Path.Combine(wwwRootPath, trimmedUrl);

					if (System.IO.File.Exists(path))
					{
						System.IO.File.Delete(path);
					}
				}
			}

			foreach (var carouselImage in carouselImages)
			{
				if (!string.IsNullOrEmpty(carouselImage.ImageUrl))
				{
					string trimmedUrl = carouselImage.ImageUrl.TrimStart('/', '\\');
					string path = Path.Combine(wwwRootPath, trimmedUrl);

					if (System.IO.File.Exists(path))
					{
						System.IO.File.Delete(path);
					}
				}
			}

			_unitOfWork.Project.Remove(project);
			_unitOfWork.Save();

			return RedirectToAction("Index");
		}

		// Custom Methods
		private void UpsertImage(IFormFile? file, ProjectVM projectVM, string PropertyName)
		{
			string wwwRootPath = _webHostEnvironment.WebRootPath;
			if (file != null)
			{
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
				string productPath = @"images\project\project-" + projectVM.Project.Id;
				string finalPath = Path.Combine(wwwRootPath, productPath);

				if (!Directory.Exists(finalPath))
				{
					Directory.CreateDirectory(finalPath);
				}

				using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
				{
					file.CopyTo(fileStream);
				}

				switch (PropertyName)
				{
					case "ImageUrl":
						projectVM.Project.ImageUrl = @"\" + productPath + @"\" + fileName;
						break;
					case "ColorsImageUrl":
						projectVM.Project.ColorsImageUrl = @"\" + productPath + @"\" + fileName;
						break;
					case "FontImageUrl":
						projectVM.Project.FontImageUrl = @"\" + productPath + @"\" + fileName;
						break;
				}

				_unitOfWork.Project.Update(projectVM.Project);
				_unitOfWork.Save();
			}

		}

		private void UpsertImages(List<IFormFile>? files, ProjectVM projectVM)
		{
			string wwwRootPath = _webHostEnvironment.WebRootPath;
			if (files != null || files?.Count > 0)
			{
				foreach (var file in files)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					string productPath = @"images\project\project-" + projectVM.Project.Id;
					string finalPath = Path.Combine(wwwRootPath, productPath);

					if (!Directory.Exists(finalPath))
					{
						Directory.CreateDirectory(finalPath);
					}

					using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}

					CarouselImage carouselImage = new()
					{
						Id = Guid.NewGuid(),
						ProjectId = projectVM.Project.Id,
						ImageUrl = @"\" + productPath + @"\" + fileName
					};

					projectVM.CarouselImage = carouselImage;

					_unitOfWork.CarouselImage.Add(projectVM.CarouselImage);
					_unitOfWork.Save();
				}
			}
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Movizi_Portal.Data;
using Movizi_Portal.Models;
using Movizi_Portal.Repository.IRepository;

namespace Movizi_Portal.Controllers
{
	public class ServiceController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public ServiceController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			List<Service> services = _unitOfWork.Service.GetAll().ToList();
			return View(services);
		}

		public IActionResult Upsert(int? id)
		{
			if (id == null || id == 0)
			{
				// Create
				return View();
			}
			else
			{
				// Edit
				Service serviceFromDb = _unitOfWork.Service.Get(x => x.Id == id);
				return View(serviceFromDb);
			}
		}

		[HttpPost]
		public IActionResult Upsert(Service Service)
		{
			if (ModelState.IsValid)
			{
				if (Service.Id == 0)
				{
					// Create
					_unitOfWork.Service.Add(Service);
				}
				else
				{
					// Edit
					_unitOfWork.Service.Update(Service);
				}
				_unitOfWork.Save();
				return RedirectToAction("Index");
			}

			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Service serviceFromDb = _unitOfWork.Service.Get(x => x.Id == id);

			if (serviceFromDb == null)
			{
				return NotFound();
			}

			return View(serviceFromDb);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
			Service service = _unitOfWork.Service.Get(x => x.Id == id);

			if (service == null)
			{
				return NotFound();
			}

			_unitOfWork.Service.Remove(service);
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}
	}
}

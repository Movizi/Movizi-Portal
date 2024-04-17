using Microsoft.AspNetCore.Mvc;
using Movizi_Portal.Models;
using Movizi_Portal.Repository.IRepository;

namespace Movizi_Portal.Controllers
{
	public class IndustryController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public IndustryController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			List<Industry> industries = _unitOfWork.Industry.GetAll().ToList();
			return View(industries);
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
				Industry industryFromDb = _unitOfWork.Industry.Get(x => x.Id == id);
				return View(industryFromDb);
			}
		}

		[HttpPost]
		public IActionResult Upsert(Industry industry)
		{
			if (ModelState.IsValid)
			{
				if (industry.Id == 0)
				{
					// Create
					_unitOfWork.Industry.Add(industry);
				}
				else
				{
					// Edit
					_unitOfWork.Industry.Update(industry);
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

			Industry industryFromDb = _unitOfWork.Industry.Get(x => x.Id == id);

			if (industryFromDb == null)
			{
				return NotFound();
			}

			return View(industryFromDb);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
			Industry industry = _unitOfWork.Industry.Get(x => x.Id == id);

			if (industry == null)
			{
				return NotFound();
			}

			_unitOfWork.Industry.Remove(industry);
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}
	}
}

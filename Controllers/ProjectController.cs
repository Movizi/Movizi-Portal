using Microsoft.AspNetCore.Mvc;
using Movizi_Portal.Data;
using Movizi_Portal.Models;

namespace Movizi_Portal.Controllers
{
	public class ProjectController : Controller
	{
		private readonly ApplicationDbContext _db;
		public ProjectController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			List<Project> projectList = _db.Projects.ToList();
			return View(projectList);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Project newProject)
		{
			if (ModelState.IsValid)
			{
				_db.Projects.Add(newProject);
				_db.SaveChanges();
				RedirectToAction("Index");
			}
			return View();
		}
	}
}

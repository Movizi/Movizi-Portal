using Microsoft.AspNetCore.Mvc;

namespace Movizi_Portal.Controllers
{
	public class ServiceController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

using Microsoft.AspNetCore.Mvc;

namespace Movizi_Portal.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

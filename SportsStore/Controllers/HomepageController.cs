using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class HomepageController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Static/Homepage.cshtml");
        }
    }
}

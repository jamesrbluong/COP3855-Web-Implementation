using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class BackgroundController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Static/Background.cshtml");

        }
    }
}

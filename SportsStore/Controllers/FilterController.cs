using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class PolicyController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Static/Policy.cshtml");

        }
    }
}

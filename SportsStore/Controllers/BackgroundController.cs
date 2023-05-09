using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class FilterController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Static/Filter.cshtml");

        }
    }
}

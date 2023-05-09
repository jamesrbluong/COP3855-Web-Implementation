using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class NewsReleaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

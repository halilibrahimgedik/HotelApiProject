using Microsoft.AspNetCore.Mvc;

namespace MyHotel.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            return View();
        }
    }
}

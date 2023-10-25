using Microsoft.AspNetCore.Mvc;

namespace MyHotel.WebUI.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

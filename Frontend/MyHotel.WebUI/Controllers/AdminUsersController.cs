using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyHotel.EntityLayer.Concrete;

namespace MyHotel.WebUI.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminUsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();

            return View(values);
        }
    }
}

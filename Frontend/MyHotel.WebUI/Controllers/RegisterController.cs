using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyHotel.EntityLayer.Concrete;
using MyHotel.WebUI.DTOs.RegisterDto;

namespace MyHotel.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AddNewUserDto newUser)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","girdiğiniz bilgiler hatalı");
                return View();
            }

            var appUser = new AppUser()
            {
                Name = newUser.Name,
                Surname = newUser.Surname,
                Email = newUser.Mail,
                UserName = newUser.UserName,
            };

            // burada istersek email yada username kontrolü yapabiliriz diğer kullanıcılar ile aynı olmaması için
            var result = await _userManager.CreateAsync(appUser,newUser.Password);
            
            if(result.Succeeded)
            {
                // kullanıcı login sayfasına yönlendirilecek,
                return RedirectToAction("Login","Login");
            }

            return View();
        }
    }
}

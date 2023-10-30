using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyHotel.EntityLayer.Concrete;
using MyHotel.WebUI.DTOs.LoginDto;

namespace MyHotel.WebUI.Controllers
{
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            if (ModelState.IsValid)
            { 
                var result = await _signInManager.PasswordSignInAsync(dto.UserName,dto.Password,false,false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Staff");
                }
            }

            return View();
        }
    }
}

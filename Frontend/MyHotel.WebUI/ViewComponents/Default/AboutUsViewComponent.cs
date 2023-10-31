using Microsoft.AspNetCore.Mvc;

namespace MyHotel.WebUI.ViewComponents.Default
{
    public class AboutUsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

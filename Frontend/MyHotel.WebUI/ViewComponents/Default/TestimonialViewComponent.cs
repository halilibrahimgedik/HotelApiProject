using Microsoft.AspNetCore.Mvc;

namespace MyHotel.WebUI.ViewComponents.Default
{
    public class TestimonialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

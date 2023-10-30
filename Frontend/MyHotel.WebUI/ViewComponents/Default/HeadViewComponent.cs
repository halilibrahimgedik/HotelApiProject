using Microsoft.AspNetCore.Mvc;

namespace MyHotel.WebUI.ViewComponents.Default
{
    public class HeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

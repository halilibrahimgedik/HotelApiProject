using Microsoft.AspNetCore.Mvc;

namespace MyHotel.WebUI.ViewComponents.Contact
{
    public class ContactViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

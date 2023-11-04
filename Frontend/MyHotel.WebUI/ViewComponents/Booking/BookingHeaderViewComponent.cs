using Microsoft.AspNetCore.Mvc;

namespace MyHotel.WebUI.ViewComponents.Booking
{
    public class BookingHeaderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

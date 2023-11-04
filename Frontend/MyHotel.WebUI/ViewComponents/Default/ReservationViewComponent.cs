using Microsoft.AspNetCore.Mvc;

namespace MyHotel.WebUI.ViewComponents.Default
{
    public class ReservationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}

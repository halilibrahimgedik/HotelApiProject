﻿using Microsoft.AspNetCore.Mvc;

namespace MyHotel.WebUI.ViewComponents.Default
{
    public class TrailerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;

namespace SonaHotel.ViewComponents
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

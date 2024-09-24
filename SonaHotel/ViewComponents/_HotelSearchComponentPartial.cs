using Microsoft.AspNetCore.Mvc;

namespace SonaHotel.ViewComponents
{
    public class _HotelSearchComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

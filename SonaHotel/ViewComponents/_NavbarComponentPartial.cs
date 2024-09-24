using Microsoft.AspNetCore.Mvc;

namespace SonaHotel.ViewComponents
{
    public class _NavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

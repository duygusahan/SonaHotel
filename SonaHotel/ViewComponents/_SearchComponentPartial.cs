using Microsoft.AspNetCore.Mvc;

namespace SonaHotel.ViewComponents
{
    public class _SearchComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

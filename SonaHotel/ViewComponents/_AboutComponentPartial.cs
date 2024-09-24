using Microsoft.AspNetCore.Mvc;

namespace SonaHotel.ViewComponents
{
    public class _AboutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

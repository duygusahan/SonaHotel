using Microsoft.AspNetCore.Mvc;

namespace SonaHotel.ViewComponents
{
    public class _ScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

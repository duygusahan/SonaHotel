using Microsoft.AspNetCore.Mvc;

namespace SonaHotel.ViewComponents
{
    public class _FeatureHotelsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

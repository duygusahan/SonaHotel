using Microsoft.AspNetCore.Mvc;

namespace SonaHotel.ViewComponents
{
    public class _HeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

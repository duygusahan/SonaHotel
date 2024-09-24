using Microsoft.AspNetCore.Mvc;

namespace SonaHotel.ViewComponents
{
    public class _FooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

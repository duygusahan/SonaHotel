using Microsoft.AspNetCore.Mvc;

namespace SonaHotel.ViewComponents
{
    public class _ServiceComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}

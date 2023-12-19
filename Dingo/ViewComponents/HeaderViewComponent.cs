using Microsoft.AspNetCore.Mvc;

namespace Dingo.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

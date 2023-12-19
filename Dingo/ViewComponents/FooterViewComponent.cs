using Microsoft.AspNetCore.Mvc;

namespace Dingo.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

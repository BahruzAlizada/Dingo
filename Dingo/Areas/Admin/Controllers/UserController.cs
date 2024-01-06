using Microsoft.AspNetCore.Mvc;

namespace Dingo.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

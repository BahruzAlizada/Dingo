
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Controllers
{
	public class MenuController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

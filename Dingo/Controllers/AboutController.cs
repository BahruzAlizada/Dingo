using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Controllers
{
	public class AboutController : Controller
	{
		private readonly IAboutService aboutService;
        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

		#region Index
		public IActionResult Index()
		{
			About about = aboutService.GetAbout();
			return View(about);
		}
		#endregion

	}
}

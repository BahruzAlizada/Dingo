using BusinessLayer.Abstract;
using Dingo.Models;
using Dingo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dingo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService sliderService;
        private readonly IAboutService aboutService;

        public HomeController(ISliderService sliderService,IAboutService aboutService)
        {
            this.sliderService = sliderService;
            this.aboutService = aboutService;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Slider = await sliderService.GetSliderAsync(),
                About = await aboutService.GetAboutAsync()
            };
            return View(homeVM);
        }
        #endregion



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
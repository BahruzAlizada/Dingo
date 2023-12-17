using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            this.testimonialService=testimonialService;
        }

        #region Index
        public IActionResult Index()
        {
            List<Testimonial> testimonials = testimonialService.GetAllTestimonials();
            return View(testimonials);
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
        {
            testimonialService.Activity(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}

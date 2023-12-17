using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.ViewComponents
{
	public class TestimonialViewComponent : ViewComponent
	{
		private readonly ITestimonialService testimonialService;
        public TestimonialViewComponent(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Testimonial> testimonials = await testimonialService.GetTestimonials(3);
            return View(testimonials);
        }
    }
}

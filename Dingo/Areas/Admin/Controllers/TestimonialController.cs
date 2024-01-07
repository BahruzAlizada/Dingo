using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Superadmin")]
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

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(TestimonialDto testimonialDto)
        {
            testimonialService.Add(testimonialDto);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Testimonial dbTestimonial = testimonialService.GetTestimonial(id);
            if (dbTestimonial == null) return BadRequest();

            TestimonialDto dbTestimonialDto = new TestimonialDto
            {
                Id = dbTestimonial.Id,
                FullName = dbTestimonial.FullName,
                Message = dbTestimonial.Message,
                IsDeactive = dbTestimonial.IsDeactive,
            };

            return View(dbTestimonialDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int? id,TestimonialDto testimonialDto)
        {
            if (id == null) return NotFound();
            Testimonial dbTestimonial = testimonialService.GetTestimonial(id);
            if (dbTestimonial == null) return BadRequest();

            TestimonialDto dbTestimonialDto = new TestimonialDto
            {
                Id = dbTestimonial.Id,
                FullName = dbTestimonial.FullName,
                Message = dbTestimonial.Message,
                IsDeactive = dbTestimonial.IsDeactive,
            };

            dbTestimonialDto.Id = testimonialDto.Id;
            dbTestimonialDto.FullName = testimonialDto.FullName;
            dbTestimonialDto.Message = testimonialDto.Message;
            dbTestimonial.IsDeactive = testimonialDto.IsDeactive;

            testimonialService.Update(testimonialDto);
            return RedirectToAction("Index");
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

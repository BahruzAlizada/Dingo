using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Superadmin")]
    public class SliderController : Controller
    {
        private readonly ISliderService sliderService;

        public SliderController(ISliderService sliderService)
        {
            this.sliderService = sliderService;
        }

        #region Index
        public IActionResult Index()
        {
            Slider slider = sliderService.GetSlider();
            return View(slider);
        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Slider dbSlider = sliderService.GetSliderById(id);
            if (dbSlider == null) return BadRequest();

            SliderDto dbSliderDto = new SliderDto
            {
                Id = dbSlider.Id,
                Title = dbSlider.Title,
                SubTitle = dbSlider.SubTitle,
                Description = dbSlider.Description
            };

            return View(dbSliderDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int? id, SliderDto sliderDto)
        {
            if (id == null) return NotFound();
            Slider dbSlider = sliderService.GetSliderById(id);
            if (dbSlider == null) return BadRequest();

            SliderDto dbSliderDto = new SliderDto
            {
                Id=dbSlider.Id,
                Title=dbSlider.Title,
                SubTitle=dbSlider.SubTitle,
                Description=dbSlider.Description
            };

            dbSliderDto.Id = sliderDto.Id;
            dbSliderDto.Title = sliderDto.Title;
            dbSliderDto.SubTitle = sliderDto.SubTitle;
            dbSliderDto.Description = sliderDto.Description;

            sliderService.Update(sliderDto);
            return RedirectToAction("Index");
        }
        #endregion

    }
}

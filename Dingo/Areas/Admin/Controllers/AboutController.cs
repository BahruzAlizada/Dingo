using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin,Superadmin")]
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

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            About dbAbout = aboutService.GetAboutById(id);
            if(dbAbout == null) return BadRequest();

            AboutDto dbAboutDto = new AboutDto
            {
                Id = dbAbout.Id,
                Title = dbAbout.Title,
                SubTitle = dbAbout.SubTitle,
                Description = dbAbout.Description,
            };

            return View(dbAboutDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int? id,AboutDto aboutDto)
        {
            if (id == null) return NotFound();
            About dbAbout = aboutService.GetAboutById(id);
            if (dbAbout == null) return BadRequest();

            AboutDto dbAboutDto = new AboutDto
            {
                Id = dbAbout.Id,
                Title = dbAbout.Title,
                SubTitle = dbAbout.SubTitle,
                Description = dbAbout.Description,
            };

            dbAboutDto.Id = aboutDto.Id;
            dbAboutDto.Title = aboutDto.Title;
            dbAboutDto.SubTitle = aboutDto.SubTitle;
            dbAboutDto.Description = aboutDto.Description;

            aboutService.Update(aboutDto);
            return RedirectToAction("Index");
        }
        #endregion
    }
}

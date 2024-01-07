using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Superadmin")]
    public class ContactInfoController : Controller
    {
        private readonly IContactInfoService contactInfoService;
        public ContactInfoController(IContactInfoService contactInfoService)
        {
            this.contactInfoService = contactInfoService;
        }

        #region Index
        public IActionResult Index()
        {
            ContactInfo contactInfo = contactInfoService.GetContactInfo();
            return View(contactInfo);
        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            ContactInfo? dbContactInfo = contactInfoService.GetContactInfoById(id);
            if (dbContactInfo == null) return BadRequest();

            return View(dbContactInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int? id,ContactInfo contactInfo)
        {
            if (id == null) return NotFound();
            ContactInfo? dbContactInfo = contactInfoService.GetContactInfoById(id);
            if (dbContactInfo == null) return BadRequest();

            dbContactInfo.Id = contactInfo.Id;
            dbContactInfo.Address = contactInfo.Address;
            dbContactInfo.PhoneNumber = contactInfo.PhoneNumber;
            dbContactInfo.GoogleMaps = contactInfo.GoogleMaps;
            dbContactInfo.EmailAddress = contactInfo.EmailAddress;

            contactInfoService.Update(contactInfo);
            return RedirectToAction("Index");
        }
        #endregion
    }
}

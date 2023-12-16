using BusinessLayer.Abstract;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        #region Index
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Index(ContactDto contactDto)
        {
            await contactService.AddAsync(contactDto);
            return RedirectToAction("Index");
        }
        #endregion

    }
}

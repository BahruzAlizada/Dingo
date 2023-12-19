using BusinessLayer.Abstract;
using EntityLayer.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Controllers
{
	public class ReservationController : Controller
	{
		private readonly IBookingService bookingService;
        public ReservationController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        #region Index
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Index(BookingDto bookingDto)
        {
            if (bookingDto.Date < DateTime.Now)
            {
                ModelState.AddModelError("Date", "Düzgün tarixi seçin");
                return View();
            }

            if (bookingDto.Note == null)
                bookingDto.Note = "Yoxdur";

            await bookingService.AddAsync(bookingDto);
            return RedirectToAction("Index");
        }
        #endregion
    }
}

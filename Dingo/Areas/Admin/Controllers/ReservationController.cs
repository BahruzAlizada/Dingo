using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly IBookingService bookingService;
        public ReservationController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        #region Index
        public async Task<IActionResult> Index(int page=1)
        {
            int take = 20;
            ViewBag.PageCount = await bookingService.BookingPageCount(page);
            ViewBag.CurrentPage = page;

            List<Booking> bookings = await bookingService.GetBookingsWithPaged(take, page);
            return View(bookings);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            bookingService.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}

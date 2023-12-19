using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;

namespace BusinessLayer.Abstract
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookingsWithPaged(int take, int page);
        Booking GetBooking(int? id);
        Task<double> BookingPageCount(double take);
        Task AddAsync(BookingDto bookingDto);
        void Delete(int id);
    }
}

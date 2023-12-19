using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;

namespace BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal bookingDal;
        private readonly IMapper mapper;
        public BookingManager(IBookingDal bookingDal,IMapper mapper)
        {
            this.bookingDal = bookingDal;
            this.mapper= mapper;
        }


        public async Task AddAsync(BookingDto bookingDto)
        {
            Booking booking = mapper.Map<Booking>(bookingDto);
            await bookingDal.AddAsync(booking);
        }

        public async Task<double> BookingPageCount(double take)
        {
            return await bookingDal.BookingPageCount(take);
        }

        public void Delete(int id)
        {
            Booking booking = bookingDal.Get(x => x.Id == id);
            bookingDal.Delete(booking);
        }

        public Booking GetBooking(int? id)
        {
            return bookingDal.Get(x => x.Id == id);
        }

        public async Task<List<Booking>> GetBookingsWithPaged(int take, int page)
        {
            return await bookingDal.GetBookingsWithPaged(take, page);
        }
    }
}

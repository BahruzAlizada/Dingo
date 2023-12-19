using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFBookingDal : EfRepositoryBase<Booking, Context>, IBookingDal
    {
        public async Task<double> BookingPageCount(double take)
        {
            using var context = new Context();

            double pageCount = Math.Ceiling(await context.Bookings.CountAsync() / take);
            return pageCount;
        }

        public async Task<List<Booking>> GetBookingsWithPaged(int take, int page)
        {
            using var context = new Context();

            List<Booking> bookings = await context.Bookings.OrderByDescending(x => x.Id).
                Skip((page - 1) * take).Take(take).ToListAsync();
            return bookings;
        }
    }
}

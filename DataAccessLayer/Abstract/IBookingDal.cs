using Core.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
    public interface IBookingDal : IRepositoryBase<Booking>
    {
        Task<List<Booking>> GetBookingsWithPaged(int take,int page);
        Task<double> BookingPageCount(double take);
    }
}

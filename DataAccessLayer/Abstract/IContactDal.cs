using Core.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
    public interface IContactDal : IRepositoryBase<Contact>
    {
        List<Contact> GetContactsWithPaged(int take, int page);
        double ContactPageCount(double take);
    }
}

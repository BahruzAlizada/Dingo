using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFContactInfoDal : EfRepositoryBase<ContactInfo,Context>,IContactInfoDal
    {
    }
}

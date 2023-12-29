

using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContactInfoService
    {
        Task<ContactInfo> GetContactInfoAsync();
        ContactInfo GetContactInfo();
        ContactInfo GetContactInfoById(int? id);
        void Add(ContactInfo contactInfo);
        void Update(ContactInfo contactInfo);
    }
}

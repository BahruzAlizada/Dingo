using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ContactInfoManager : IContactInfoService
    {
        private readonly IContactInfoDal contactInfoDal;
        public ContactInfoManager(IContactInfoDal contactInfoDal)
        {
            this.contactInfoDal = contactInfoDal;
        }


        public void Add(ContactInfo contactInfo)
        {
            contactInfoDal.Add(contactInfo);
        }

        public ContactInfo GetContactInfo()
        {
            return contactInfoDal.Get();
        }

        public async Task<ContactInfo> GetContactInfoAsync()
        {
            return await contactInfoDal.GetAsync();
        }

        public ContactInfo GetContactInfoById(int? id)
        {
            return contactInfoDal.Get(x=>x.Id == id);
        }

        public void Update(ContactInfo contactInfo)
        {
            contactInfoDal.Update(contactInfo);
        }
    }
}

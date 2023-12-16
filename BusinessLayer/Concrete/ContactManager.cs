using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal contactDal;
        private readonly IMapper mapper;
        public ContactManager(IContactDal contactDal,IMapper mapper)
        {
            this.contactDal = contactDal;
            this.mapper = mapper;
        }

        public async Task AddAsync(ContactDto contactDto)
        {
            var contact = mapper.Map<Contact>(contactDto);
            await contactDal.AddAsync(contact);
        }

        public double ContactPageCount(double take)
        {
            return contactDal.ContactPageCount(take);
        }

        public void Delete(int id)
        {
            var contact = contactDal.Get(x => x.Id == id);
            contactDal.Delete(contact);
        }

        public Contact GetContact(int? id)
        {
            return contactDal.Get(x => x.Id == id);
        }

        public List<Contact> GetContacts()
        {
            return contactDal.GetAll();
        }

        public List<Contact> GetContactsWithPaged(int take, int page)
        {
            return contactDal.GetContactsWithPaged(take, page);
        }
    }
}

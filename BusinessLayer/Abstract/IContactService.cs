using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;


namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetContactsWithPaged(int take, int page);
        double ContactPageCount(double take);
        List<Contact> GetContacts();
        Contact GetContact(int? id);
        Task AddAsync(ContactDto contactDto);
        void Delete(int id);
    }
}

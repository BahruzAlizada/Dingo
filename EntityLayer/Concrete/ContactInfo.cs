using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class ContactInfo : IEntity
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string GoogleMaps { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }      
    }
}

using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class Booking : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}

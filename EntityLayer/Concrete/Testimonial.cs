using CoreLayer.Entity;
using System;

namespace EntityLayer.Concrete
{
    public class Testimonial : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } 
        public string Message { get; set; }
        public bool IsDeactive { get; set; }
    }
}

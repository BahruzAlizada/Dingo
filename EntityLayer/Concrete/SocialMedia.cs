using CoreLayer.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class SocialMedia : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu xana boş ola bilməz")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Link { get; set; }
        public bool IsDeactive { get; set; }
    }
}

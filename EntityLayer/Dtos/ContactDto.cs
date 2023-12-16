using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Dto
{
    public class ContactDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Message { get; set; }
    }
}

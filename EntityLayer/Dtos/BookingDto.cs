using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Dtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Telefon nömrəsini düzgün daxil edin")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public DateTime Time { get; set; }
        public string Note { get; set; }
    }
}

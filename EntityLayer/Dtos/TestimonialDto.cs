using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Dtos
{
	public class TestimonialDto
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public string FullName { get; set; }
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public string Message { get; set; }
		public bool IsDeactive { get; set; }
	}
}

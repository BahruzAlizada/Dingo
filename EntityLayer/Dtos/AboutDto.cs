using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Dtos
{
	public class AboutDto
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Bu xana boş ola bilməz")]
		public string Title { get; set; }
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public string SubTitle { get; set; }
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public string Description { get; set; }
	}
}

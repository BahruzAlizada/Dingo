using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Dtos
{
	public class CategoryDto
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public string Name { get; set; }
		public bool IsDeactive { get; set; }
	}
}

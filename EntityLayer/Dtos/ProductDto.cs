using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Dtos
{
	public class ProductDto
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		[NotMapped]
		public IFormFile? Photo { get; set; }
		public string Image { get; set; }
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Bu xana boş ola bilməz")]
		public double Price { get; set; }
		public bool IsDeactive { get; set; }
	}
}

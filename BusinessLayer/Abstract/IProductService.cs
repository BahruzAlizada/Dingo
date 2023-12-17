using EntityLayer.Dtos;
using System;


namespace BusinessLayer.Abstract
{
	public interface IProductService
	{
		void Activity(int id);
		Task AddAsync(ProductDto productDto);
		Task UpdateAsync(ProductDto productDto);
		void Delete(int? id);
	}
}

using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;


namespace BusinessLayer.Abstract
{
	public interface IProductService
	{
		void Activity(int id);
		Task<Product> GetProductAsync(int? id);
        Task<List<Product>> GetProductsWithPaged(int take, int page);
        Task<int> PageCount(double take);
        Task AddAsync(ProductDto productDto);
		Task UpdateAsync(ProductDto productDto);
		void Delete(int? id);
	}
}

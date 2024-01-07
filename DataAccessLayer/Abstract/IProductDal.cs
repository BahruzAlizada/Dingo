using Core.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
	public interface IProductDal : IRepositoryBase<Product>
	{
		void Activity(int id);
		Task<List<Product>> GetProductsWithPaged(int take,int page);
		Task<List<Product>> GetActiveProductsWithCategory();
		Task<int> PageCount(double take);
	}
}

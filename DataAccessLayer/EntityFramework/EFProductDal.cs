using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;

namespace DataAccessLayer.EntityFramework
{
	public class EFProductDal : EfRepositoryBase<Product, Context>, IProductDal
	{
		public void Activity(int id)
		{
			using var context = new Context();

			Product product = context.Products.FirstOrDefault(p => p.Id == id);
			if (product.IsDeactive)
				product.IsDeactive = false;
			else
				product.IsDeactive = true;

			context.SaveChanges();
		}
	}
}

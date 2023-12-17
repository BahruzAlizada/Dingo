using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Product>> GetProductsWithPaged(int take, int page)
        {
            using var context = new Context();

			List<Product> products = await context.Products.Include(x=>x.Category).OrderByDescending(x=>x.Id).
				Skip((page-1)*take).Take(take).ToListAsync();
			return products;
        }

        public async Task<int> PageCount(double take)
        {
			using var context = new Context();

			int pagecount = (int)Math.Ceiling(await context.Products.CountAsync() / take);
			return pagecount;
        }
    }
}

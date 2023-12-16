using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata.Ecma335;

namespace DataAccessLayer.EntityFramework
{
	public class EFCategoryDal : EfRepositoryBase<Category, Context>, ICategoryDal
	{
		public void Activity(int id)
		{
			using var context = new Context();
			Category category = context.Categories.FirstOrDefault(c => c.Id == id);
			if(category.IsDeactive)
				category.IsDeactive=false;
			else
				category.IsDeactive=true;

			context.SaveChanges();
		}

		public async Task<List<Category>> GetActiveCategories()
		{
			using var context = new Context();
			List<Category> categories = await context.Categories.Where(x => !x.IsDeactive).ToListAsync();
			return categories;
		}
	}
}

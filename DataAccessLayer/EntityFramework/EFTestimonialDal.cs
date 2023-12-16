using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.EntityFramework
{
	public class EFTestimonialDal : EfRepositoryBase<Testimonial, Context>, ITestimonialDal
	{
		public void Activity(int id)
		{
			using var context = new Context();
			Testimonial testimonial = context.Testimonials.FirstOrDefault(x => x.Id == id);
			if (testimonial.IsDeactive)
				testimonial.IsDeactive = false;
			else
				testimonial.IsDeactive = true;

			context.SaveChanges();
		}

		public async Task<List<Testimonial>> GetTestimonials(int take)
		{
			using var context = new Context();

			List<Testimonial> testimonials = await context.Testimonials.Where(x=>!x.IsDeactive).OrderByDescending(x=>x.Id).
				Take(take).ToListAsync();
			return testimonials;
		}
	}
}

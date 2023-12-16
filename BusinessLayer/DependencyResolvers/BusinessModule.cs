using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace BusinessLayer.DependencyResolvers
{
    public static class BusinessModule
    {
        public static void BusinessLoad(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();

			services.AddScoped<IProductService, ProductManager>();
			services.AddScoped<IProductDal, EFProductDal>();

			services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EFAboutDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EFContactDal>();

			services.AddScoped<ISliderService, SliderManager>();
			services.AddScoped<ISliderDal, EFSliderDal>();

			services.AddScoped<ITestimonialService, TestimonialManager>();
			services.AddScoped<ITestimonialDal,EFTestimonialDal>();
		}
    }
}

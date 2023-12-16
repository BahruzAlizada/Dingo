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
            //services.AddScoped<ICategoryService, CategoryManager>();
            //services.AddScoped<ICategoryDal, EFCategoryDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EFContactDal>();


            //services.AddScoped<ISocialMediaService, SocialMediaManager>();
            //services.AddScoped<ISocialMediaDal,EFSocialMediaDal>();
        }
    }
}

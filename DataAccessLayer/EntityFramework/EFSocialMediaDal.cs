using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFSocialMediaDal : EfRepositoryBase<SocialMedia, Context>, ISocialMediaDal
    {
        public void Activity(int id)
        {
            using var context = new Context();
            SocialMedia socialMedia = context.SocialMedias.FirstOrDefault(x=> x.Id == id);
            if (socialMedia.IsDeactive)
                socialMedia.IsDeactive = false;
            else
                socialMedia.IsDeactive = true;

            context.SaveChanges();
        }

        public async Task<List<SocialMedia>> GetActiveSocialMedias()
        {
            using var context = new Context();

            List<SocialMedia> socialMedias = await context.SocialMedias.Where(x => !x.IsDeactive).ToListAsync();
            return socialMedias;
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal socialMediaDal;
        private readonly IMemoryCache memoryCache;
        public SocialMediaManager(ISocialMediaDal socialMediaDal,IMemoryCache memoryCache)
        {
            this.socialMediaDal = socialMediaDal;
            this.memoryCache = memoryCache;
        }


        public void Activity(int id)
        {
            socialMediaDal.Activity(id);
        }

        public void Add(SocialMedia socialMedia)
        {
            socialMediaDal.Add(socialMedia);
        }

        public void Delete(int id)
        {
            SocialMedia socialMedia = socialMediaDal.Get(x => x.Id == id);
            socialMediaDal.Delete(socialMedia);
        }

        public async Task<List<SocialMedia>> GetActiveSocialMedias()
        {
            return await socialMediaDal.GetActiveSocialMedias();
        }

        public async Task<List<SocialMedia>> GetActiveCachingSocialMedias()
        {
            const string cachingKey= "socialMedias";
            List<SocialMedia> socialMedias;
            
            if(!memoryCache.TryGetValue(cachingKey, out socialMedias))
            {
                socialMedias = await socialMediaDal.GetActiveSocialMedias();

                memoryCache.Set(cachingKey, socialMedias,new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(3),
                    AbsoluteExpirationRelativeToNow =TimeSpan.FromMinutes(9),
                    Priority=CacheItemPriority.High
                });
            }

            return socialMedias;
        }

        public SocialMedia GetSocialMedia(int? id)
        {
            return socialMediaDal.Get(x => x.Id == id);
        }

        public List<SocialMedia> GetSocialMedias()
        {
            return socialMediaDal.GetAll();
        }

        public void Update(SocialMedia socialMedia)
        {
            socialMediaDal.Update(socialMedia);
        }
    }
}

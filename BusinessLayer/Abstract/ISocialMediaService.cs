using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface ISocialMediaService
    {
        Task<List<SocialMedia>> GetActiveCachingSocialMedias();
        Task<List<SocialMedia>> GetActiveSocialMedias();
        List<SocialMedia> GetSocialMedias();
        SocialMedia GetSocialMedia(int? id);
        void Add(SocialMedia socialMedia);
        void Update(SocialMedia socialMedia);
        void Activity(int id);
        void Delete(int id);
    }
}

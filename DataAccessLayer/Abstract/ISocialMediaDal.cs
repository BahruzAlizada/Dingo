﻿using Core.DataAccess;
using EntityLayer.Concrete;
using System;

namespace DataAccessLayer.Abstract
{
    public interface ISocialMediaDal : IRepositoryBase<SocialMedia>
    {
        void Activity(int id);
        Task<List<SocialMedia>> GetActiveSocialMedias();
    }
}

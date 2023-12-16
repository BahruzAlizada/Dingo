using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;

namespace BusinessLayer.Concrete
{
	public class AboutManager : IAboutService
	{
		private readonly IAboutDal aboutDal;
		private readonly IMapper mapper;
        public AboutManager(IAboutDal aboutDal,IMapper mapper)
        {
            this.aboutDal = aboutDal;
			this.mapper=mapper;
        }


        public About GetAbout()
		{
			return aboutDal.Get();
		}

		public About GetAboutById(int id)
		{
			return aboutDal.Get(x => x.Id == id);
		}

		public void Update(AboutDto aboutDto)
		{
			About about = mapper.Map<About>(aboutDto);
			aboutDal.Update(about);
		}
	}
}

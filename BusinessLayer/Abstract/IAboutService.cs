using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;

namespace BusinessLayer.Abstract
{
	public interface IAboutService
	{
		Task<About> GetAboutAsync();
		About GetAbout();
		About GetAboutById(int id);
		void Update(AboutDto aboutDto);
	}
}

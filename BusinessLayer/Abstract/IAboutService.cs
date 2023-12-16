using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;

namespace BusinessLayer.Abstract
{
	public interface IAboutService
	{
		About GetAbout();
		About GetAboutById(int id);
		void Update(AboutDto aboutDto);
	}
}

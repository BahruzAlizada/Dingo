using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;


namespace BusinessLayer.Abstract
{
	public interface ISliderService
	{
		Task<Slider> GetSliderAsync();
		Slider GetSlider();
		Slider GetSliderById(int? id);
		void Update(SliderDto sliderDto);
	}
}

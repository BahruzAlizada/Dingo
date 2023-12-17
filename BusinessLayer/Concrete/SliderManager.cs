using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;

namespace BusinessLayer.Concrete
{
	public class SliderManager : ISliderService
	{
		private readonly ISliderDal sliderDal;
		private readonly IMapper mapper;
        public SliderManager(ISliderDal sliderDal,IMapper mapper)
        {
            this.sliderDal=sliderDal;
			this.mapper=mapper;
        }

        public Slider GetSlider()
        {
			return sliderDal.Get();
        }

        public async Task<Slider> GetSliderAsync()
        {
			return await sliderDal.GetAsync();
        }

        public Slider GetSliderById(int? id)
		{
			return sliderDal.Get(x => x.Id == id);
		}

		public void Update(SliderDto sliderDto)
		{
			Slider slider = mapper.Map<Slider>(sliderDto);
			sliderDal.Update(slider);
		}
	}
}

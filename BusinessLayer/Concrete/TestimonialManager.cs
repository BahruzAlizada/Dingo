using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;

namespace BusinessLayer.Concrete
{
	public class TestimonialManager : ITestimonialService
	{
		private readonly ITestimonialDal testimonialDal;
		private readonly IMapper mapper;
        public TestimonialManager(ITestimonialDal testimonialDal,IMapper mapper)
        {
            this.testimonialDal = testimonialDal;
			this.mapper = mapper;
        }

        public void Activity(int id)
		{
			testimonialDal.Activity(id);
		}

		public void Add(TestimonialDto testimonialDto)
		{
			Testimonial testimonial = mapper.Map<Testimonial>(testimonialDto);
			testimonialDal.Add(testimonial);
		}

		public void Delete(int? id)
		{
			Testimonial testimonial = testimonialDal.Get(x => x.Id == id);
			testimonialDal.Delete(testimonial);
		}

		public List<Testimonial> GetAllTestimonials()
		{
			return testimonialDal.GetAll();
		}

		public Testimonial GetTestimonial(int? id)
		{
			return testimonialDal.Get(x => x.Id == id);
		}

		public async Task<List<Testimonial>> GetTestimonials(int take)
		{
			return await testimonialDal.GetTestimonials(take);
		}

		public void Update(TestimonialDto testimonialDto)
		{
			Testimonial testimonial = mapper.Map<Testimonial>(testimonialDto);
			testimonialDal.Update(testimonial);
		}
	}
}

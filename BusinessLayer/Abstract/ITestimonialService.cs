using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;

namespace BusinessLayer.Abstract
{
	public interface ITestimonialService
	{
		void Activity(int id);
		Task<List<Testimonial>> GetTestimonials(int take);
		List<Testimonial> GetAllTestimonials();
		Testimonial GetTestimonial(int? id);
		void Add(TestimonialDto testimonialDto);
		void Update(TestimonialDto testimonialDto);
		void Delete(int? id);
	}
}

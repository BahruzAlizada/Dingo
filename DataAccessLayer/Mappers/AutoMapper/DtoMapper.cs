using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using EntityLayer.Dtos;
using System;


namespace DataAccessLayer.Mappers.AutoMapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Slider, SliderDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<About,AboutDto>().ReverseMap();
            CreateMap<Testimonial,TestimonialDto>().ReverseMap();
        }
    }
}

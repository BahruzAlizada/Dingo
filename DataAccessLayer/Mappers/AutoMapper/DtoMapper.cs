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
            CreateMap<Slider, SliderDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<About,AboutDto>().ReverseMap();
        }
    }
}

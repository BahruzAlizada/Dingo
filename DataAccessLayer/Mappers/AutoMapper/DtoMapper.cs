using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;


namespace DataAccessLayer.Mappers.AutoMapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}

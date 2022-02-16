using AutoMapper;
using Domain.Entities;
using FunctionalDisorder.Models.ActionDTOs;
using System;

namespace Services.Mappers
{
    public class ApiToEntityProfile : Profile
    {
        public ApiToEntityProfile()
        {
            CreateMap<SignUpModelDto, User>();
        }
    }
}

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
            CreateMap<UserForCreationDto, User>()
                .ForMember(x => x.Id, p => p.MapFrom(src => Guid.NewGuid().ToString()));
        }
    }
}

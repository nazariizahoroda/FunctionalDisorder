using AutoMapper;
using Domain.Entities;
using FunctionalDisorder.Models.ViewDTOs;

namespace Services.Mappers
{
    public class EntityToViewProfile : Profile
    {
        public EntityToViewProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}

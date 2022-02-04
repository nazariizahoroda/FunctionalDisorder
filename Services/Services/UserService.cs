using AutoMapper;
using Domain.Entities;
using Domain.Repository_interfaces;
using FunctionalDisorder.Models.ActionDTOs;
using FunctionalDisorder.Models.ViewDTOs;
using Services.Abstractions.Service_interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateAsync(UserForCreationDto userForCreationDto, CancellationToken cancellationToken = default)
        {
            var user = _mapper.Map<User>(userForCreationDto);

            await _repositoryManager.User.CreateAsync(user);

            await _repositoryManager.SaveAsync();

            return _mapper.Map<UserDto>(user);
        }
    }
}

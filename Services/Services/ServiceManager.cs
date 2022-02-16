using AutoMapper;
using Domain.Entities;
using Domain.Repository_interfaces;
using Microsoft.AspNetCore.Identity;
using Services.Abstractions.Service_interfaces;

namespace Services.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, 
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IUserService UserService => new UserService(_repositoryManager, _mapper, _userManager, _signInManager);
    }
}

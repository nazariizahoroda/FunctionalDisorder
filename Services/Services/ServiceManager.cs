using AutoMapper;
using Domain.Repository_interfaces;
using Services.Abstractions.Service_interfaces;

namespace Services.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public IUserService UserService => new UserService(_repositoryManager, _mapper);
    }
}

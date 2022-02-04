using Domain.Repository_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationContext _applicationContext;

        public RepositoryManager(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IUserRepository User => new UserRepository(_applicationContext);

        public async Task SaveAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }
    }
}

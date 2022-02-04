using Domain.Entities;
using Domain.Repository_interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext applicationContext)
            :base(applicationContext)
        {

        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await FindAll()
            .OrderBy(user => user.Name)
            .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await FindByCondition(user => user.Id.Equals(userId))
            .FirstOrDefaultAsync();
        }

        public Task<User> GetUserWithDetailsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}

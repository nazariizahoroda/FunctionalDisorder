using System.Threading.Tasks;

namespace Domain.Repository_interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        Task SaveAsync();
    }
}

using FunctionalDisorder.Models.ActionDTOs;
using FunctionalDisorder.Models.ViewDTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions.Service_interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(UserForCreationDto userForCreationDto, CancellationToken cancellationToken = default);
    }
}

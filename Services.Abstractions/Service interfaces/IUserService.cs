using FunctionalDisorder.Models.ActionDTOs;
using FunctionalDisorder.Models.ViewDTOs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions.Service_interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(SignUpModelDto model, CancellationToken cancellationToken = default);
        Task<UserDto> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default);
        Task<TokenDto> SignInUserAsync(SignInModelDto model, CancellationToken cancellationToken = default);
    }
}
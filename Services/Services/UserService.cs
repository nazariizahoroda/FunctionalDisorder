using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repository_interfaces;
using FunctionalDisorder.Models.ActionDTOs;
using FunctionalDisorder.Models.ViewDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Services.Abstractions.Service_interfaces;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(IRepositoryManager repositoryManager, IMapper mapper, 
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserDto> CreateUserAsync(SignUpModelDto model, CancellationToken cancellationToken = default)
        {
            var user = _mapper.Map<User>(model);

            await _userManager.CreateAsync(user, model.Password);

            await _userManager.AddToRoleAsync(user, "RegistredUser");

            return _mapper.Map<UserDto>(user);
        }


        public async Task<TokenDto> SignInUserAsync(SignInModelDto model, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("User is not authorized");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);

                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                };

                foreach (var userRole in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var userClaims = await _userManager.GetClaimsAsync(user);

                claims.AddRange(userClaims);

                var now = DateTime.UtcNow;

                var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                return new TokenDto
                {
                    access_token = encodedJwt,
                    username = user.UserName
                };
            }
            throw new UnauthorizedAccessException("User is not authorized");
        }


        /// <summary>method <c>GetUserById</c> return user info by user's id</summary>
        public async Task<UserDto> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var user = await _repositoryManager.User.GetUserByIdAsync(userId);

            if (user == null)
            {
                throw new ItemNotFoundException("User not found");
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}

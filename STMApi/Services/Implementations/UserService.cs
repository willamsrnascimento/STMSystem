using Microsoft.AspNetCore.Identity;
using STMApi.Security.Token;
using STMApi.Services.Interfaces;
using STMComunication.Dtos;
using System.Security.Claims;

namespace STMApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> UserLoginAsync(LoginRequestDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return null;
            }

            var subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, loginDto.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            });

            return TokenGenerator.GenerateToken(subject);
        }

        public async Task<string> CreateUserAsync(UserRequestDto user)
        {
            var newUser = new IdentityUser { Email = user.Email, UserName = user.NormalizeUserName(), PhoneNumber = user.PhoneNumber };
            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (!result.Succeeded)
            {
                throw new Exception("It was not possible to create a new user.");
            }

            return newUser.Id;
        }
    }
}

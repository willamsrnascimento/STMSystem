using Microsoft.AspNetCore.Identity;
using STMApi.Security.Token;
using STMComunication.Dtos;
using System.Security.Claims;

namespace STMApi.Services.Implementations
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> UserLogin(LoginRequestDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.userName);
            
            if (user == null)
            {
                return string.Empty;
            }

            if(! await _userManager.CheckPasswordAsync(user, loginDto.password))
            {
                return string.Empty;
            }

            var subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, loginDto.userName),
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

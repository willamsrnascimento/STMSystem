using Microsoft.AspNetCore.Identity;
using STMComunication.Services.Interfaces;
using System.Security.Claims;
using STMComunication.Dtos.User;
using STMComunication.Dtos.Login;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using STMDomain.Domain;

namespace STMComunication.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<LoginResponseDto> UserLoginAsync(LoginRequestDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return null;
            }

            var claim = _userManager.GetClaimsAsync(user).Result.FirstOrDefault();

            var subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, claim.Value)
            });

          

            LoginResponseDto loginResponseDto = new LoginResponseDto
            {
                UserName = user.UserName,
                Name = claim.Value,
                Email = user.Email,
                Token = GenerateToken(subject),
            };

            return loginResponseDto;
        }

        public async Task<string> CreateUserAsync(UserRequestDto user)
        {
            var newUser = new IdentityUser { Email = user.Email, UserName = user.GetSimplifiedUserName(), PhoneNumber = user.PhoneNumber };

            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (!result.Succeeded)
            {
                throw new Exception("It was not possible to create a new user.");
            }

            var claimResult = await _userManager.AddClaimAsync(newUser, new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"));

            if (!claimResult.Succeeded)
            {
                throw new Exception("It was not possible to create a new user. There is a problem in claim inclusion.");
            }

            return newUser.Id;
        }

        private string GenerateToken(ClaimsIdentity claimsIdentity)
        {
            var configure = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var key = Encoding.ASCII.GetBytes(configure["JwtBearerTokenSetting:SecretKey"]);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = configure["JwtBearerTokenSetting:Audience"],
                Issuer = configure["JwtBearerTokenSetting:Issuer"],
                Expires = DateTime.UtcNow.AddSeconds(220)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}

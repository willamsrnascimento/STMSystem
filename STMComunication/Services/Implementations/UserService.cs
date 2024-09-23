using Microsoft.AspNetCore.Identity;
using STMComunication.Services.Interfaces;
using System.Security.Claims;
using STMComunication.Dtos.User;
using STMComunication.Dtos.Login;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace STMComunication.Services.Implementations
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

            var subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, loginDto.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            });

            LoginResponseDto loginResponseDto = new LoginResponseDto
            {
                UserName = user.UserName,
                Name = user.NormalizedUserName,
                Email = user.Email,
                Token = GenerateToken(subject),
            };

            return loginResponseDto;
        }

        public async Task<string> CreateUserAsync(UserRequestDto user)
        {
            var newUser = new IdentityUser { Email = user.Email, UserName = user.GetSimplifiedUserName(), PhoneNumber = user.PhoneNumber, NormalizedUserName = user.Name};
            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (!result.Succeeded)
            {
                throw new Exception("It was not possible to create a new user.");
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

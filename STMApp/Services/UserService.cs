using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using STMApp.Clients.Interface;
using STMApp.Dtos;
using STMApp.Dtos.Login;
using STMApp.Security;
using STMApp.Services.Interfaces;
using System.Security.Claims;
using System.Security.Cryptography;

namespace STMApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserClient _userClient;

        public UserService(IUserClient userClient)
        {
            _userClient = userClient;
        }

        public async Task LoginAsync(HttpContext context, LoginResponseDto loginResponseDto)
        {
            context.Session.Clear();
            context.Session.SetString("JWToken", loginResponseDto.Token);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, loginResponseDto.UserName),
                    new Claim(ClaimTypes.Email, loginResponseDto.Email),
                    new Claim(ClaimTypes.Name, loginResponseDto.Name)
                };

            var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddHours(2),
                IssuedUtc = DateTime.Now,
            };

            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
        }

        public async Task LoginOutAsync(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            context.Session.Clear();
        }

        public async Task<ApiResultDataDto<LoginResponseDto>> GetLoginFromClientAsync(LoginRequestDto login)
        {
            login.Password = SecurityUtils.ComputeHash(login.Password, SHA256.Create());
            return await _userClient.GetLoginAsync(login);
        }
    }
}

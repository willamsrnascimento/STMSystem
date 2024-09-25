using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using STMApp.Dtos.Login;
using STMApp.Services.Interfaces;
using System.Security.Claims;

namespace STMApp.Services
{
    public class UserService : IUserService
    {
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
    }
}

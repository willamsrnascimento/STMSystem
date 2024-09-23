using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using STMApp.Clients.User;
using STMApp.Dtos.Login;
using System.Security.Claims;

namespace STMApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserClient _client;

        public UserController(IUserClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginRequestDto login)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.Clear();
                var user = await _client.GetLogin(login);
                HttpContext.Session.SetString("JWToken", user.Token);
               
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name)
                };

                var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddHours(2),
                    IssuedUtc = DateTime.Now,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                HttpContext.Session.Clear();
                return View(login);
            }        
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View();
        }
    }
}

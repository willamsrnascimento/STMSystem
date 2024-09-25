using Microsoft.AspNetCore.Mvc;
using STMApp.Clients.Interface;
using STMApp.Dtos.Login;
using STMApp.Security;
using STMApp.Services.Interfaces;
using System.Security.Cryptography;

namespace STMApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserClient _client;
        private readonly IUserService _userService;
        public UserController(IUserClient client, IUserService userService)
        {
            _client = client;
            _userService = userService;
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
                login.Password = SecurityUtils.ComputeHash(login.Password, SHA256.Create());
                var user = await _client.GetLoginAsync(login);

                if (user == null)
                {
                    return BadRequest();
                }

                await _userService.LoginAsync(HttpContext, user);
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
            await _userService.LoginOutAsync(HttpContext);

            return View();
        }
    }
}

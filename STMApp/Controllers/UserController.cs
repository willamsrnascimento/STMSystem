using Microsoft.AspNetCore.Mvc;
using STMApp.Dtos.Login;
using STMApp.Security;
using STMApp.Services.Interfaces;
using System.Security.Cryptography;

namespace STMApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto login)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.GetLoginFromClientAsync(login);

                if (result == null)
                {
                    return BadRequest();
                }

                if (!result.Success)
                {
                    TempData["Error"] = result.Message;
                    return View(login);
                }

                await _userService.LoginAsync(HttpContext, result.Data);
                
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

            return RedirectToAction("Login");
        }
    }
}

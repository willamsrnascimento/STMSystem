using Microsoft.AspNetCore.Mvc;
using STMApp.Dtos;
using STMApp.Services.Interfaces;

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

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _userService.LoginOutAsync(HttpContext);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequestDto userRequestDto)
        {
            string token = HttpContext.Session.GetString("JWToken");
            bool result = await _userService.CreateAsync(userRequestDto, token);

            if (result == false)
            {
                return View(userRequestDto);
            }

            TempData["Message"] = "Usuário criado com sucesso.";
            return View(new UserRequestDto());
        }
    }
}

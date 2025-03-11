using AuthenticationWitthJWT.DTOs;
using AuthenticationWitthJWT.Entitys;
using AuthenticationWitthJWT.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationWitthJWT.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthServices _authService;
        public static User _user = new();

        public AuthController(IAuthServices authservices)
        {
            _authService = authservices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Registration(User userDto)
        {
            if (!ModelState.IsValid) return View(userDto);

            var user = _authService.Register(userDto);
            return View("RegistrationSuccess", user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User userDto)
        {
            if (_authService.Login(userDto))
            {
                return View("LoginSuccess", userDto);
            }

            ViewBag.Error = "Invalid credentials.";
            return View();
        }
    }
}

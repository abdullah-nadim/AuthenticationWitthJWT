using AuthenticationWitthJWT.DTOs;
using AuthenticationWitthJWT.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationWitthJWT.Controllers
{
    public class AuthController : Controller
    {
        public static  User _user = new();
        //[Route("")]
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
        public IActionResult Registration( UserDto userDto)
        {
            if (!ModelState.IsValid) return View(userDto); 

            var hasher = new PasswordHasher<User>();
            _user.Username = userDto.Username;
            _user.Password = hasher.HashPassword(_user, userDto.Password);

            return View("RegistrationSuccess", _user);
        }
    }
}

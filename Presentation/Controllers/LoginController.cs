using DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System.Security.Claims;

namespace Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn(UserDTO userDTO) 
        {
            try
            {
                _userService.SignIn(userDTO);

                Authenticate(userDTO);

                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("SignOut")]
        public IActionResult SignOut(UserDTO userDTO)
        {
            try
            {
                HttpContext.SignOutAsync();
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Authenticate(UserDTO user)
		{
			var claims = new List<Claim>
			{
				new Claim("Id", user.Id.ToString()),
				new Claim("Username", user.Username),
				new Claim(ClaimTypes.Email, user.Email)
			};

			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie");

			HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}

	}
}

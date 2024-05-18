using EMS.Business.Services;
using EMS.Domain.DtoModels;
using EMS.Persistence.DBaseContext;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EMS.Web.Controllers
{
    public class AuthenticateUserController : Controller
    {

        private readonly EmsDbContext _context;
        private readonly AuthenticateUserService _authenticateUserService;

        public AuthenticateUserController(EmsDbContext context, AuthenticateUserService authenticateUserService)
        {
            _context = context;
            _authenticateUserService = authenticateUserService;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Login User with UserName & Password and JWT
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var appUserLoginInfo = _authenticateUserService.Authenticate(loginModel);

            if (appUserLoginInfo == null)
            {
                return View(loginModel);
            }

            // Store user information in session
            HttpContext.Session.SetString("AppUserLoginInfo", JsonConvert.SerializeObject(appUserLoginInfo));

            // Redirect to home page
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Logout User and Clear the existing Session
        /// </summary>
        /// <returns></returns>

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "AuthenticateUser");
        }



    }
}

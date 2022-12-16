using EmployeeApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace EmployeeApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }

        public IActionResult Login()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            if (claimuser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCredentials LogCred)
        {
            if (LogCred.Email == "ezhilkannan1996@gmail.com" && LogCred.Password == "123")
            {
                List<Claim> claims = new List<Claim>()
                {
                new Claim(ClaimTypes.NameIdentifier,LogCred.Email),
                new Claim("OtherProperties","Example Role")
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = LogCred.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity), properties);
                return RedirectToAction("Index", "Employee");
            }
            ViewData["ValidateMessage"] = "User not found";
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }
    }
}
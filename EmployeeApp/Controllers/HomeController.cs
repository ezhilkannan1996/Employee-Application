using EmployeeApp.Helper;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Newtonsoft.Json;

namespace EmployeeApp.Controllers
{
    public class HomeController : Controller
    {
        EmployeeAPI _api = new EmployeeAPI();
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
        public async Task<IActionResult> Login(UserData LogCred)
        {
            UserData _User=new UserData();
            HttpClient client = _api.Initial();
            string api = "api/UserDatas/" + LogCred.Email;
            HttpResponseMessage res = await client.GetAsync(api);
            if (res.IsSuccessStatusCode)
            {
                var results= res.Content.ReadAsStringAsync().Result;
                _User = JsonConvert.DeserializeObject<UserData>(results);
                
                    if(LogCred.Email == _User.Email && LogCred.Password == _User.Password)
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
            }

            
            ViewData["ValidateMessage"] = "User not found";
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
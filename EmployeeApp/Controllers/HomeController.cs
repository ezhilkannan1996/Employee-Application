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
            List<UserData> Users=new List<UserData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/UserDatas");
            if (res.IsSuccessStatusCode)
            {
                var results= res.Content.ReadAsStringAsync().Result;
                Users = JsonConvert.DeserializeObject<List<UserData>>(results);
                foreach (var item in Users)
                {
                    if(LogCred.Email==item.Email && LogCred.Password == item.Password)
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

                //if (LogCred.Email == Users[0].Email && LogCred.Password == Users[0].Password)
                //{
                //    List<Claim> claims = new List<Claim>()
                //{
                //new Claim(ClaimTypes.NameIdentifier,LogCred.Email),
                //new Claim("OtherProperties","Example Role")
                //};
                //    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //    AuthenticationProperties properties = new AuthenticationProperties()
                //    {
                //        AllowRefresh = true,
                //        IsPersistent = LogCred.KeepLoggedIn
                //    };

                //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                //        new ClaimsPrincipal(identity), properties);
                //    return RedirectToAction("Index", "Employee");
                //}
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
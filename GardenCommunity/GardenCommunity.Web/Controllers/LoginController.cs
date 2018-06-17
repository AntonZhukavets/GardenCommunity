using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using GardenCommunity.Web.Models;

namespace GardenCommunity.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserProvider userProvider;
        private readonly IRoleProvider roleProvider;
        public LoginController(IUserProvider userProvider, IRoleProvider roleProvider)
        {
            this.userProvider = userProvider;
            this.roleProvider = roleProvider;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user, string returnUrl)
        {
            var appUser = userProvider.GetUser(user.UserName, user.Password);
            var claims = new List<Claim>()
            {
                new Claim("UserId", appUser.Id.ToString()),                
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim(ClaimTypes.Role, appUser.Role.Name)
            };            
            var identity = new ClaimsIdentity("AppCookie");
            identity.AddClaims(claims);
            var principal = new ClaimsPrincipal(identity);
            var authProperties = new AuthenticationProperties()
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
            return Redirect(returnUrl);          
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("GetMembers", "Member");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var role = roleProvider.GetRole("Viewer");
                user.Role = role;
                if (userProvider.AddUser(user) != 0)
                {
                    return View("SuccessfulRegistration");
                }
            }
            return View(user);
        }
    }
}
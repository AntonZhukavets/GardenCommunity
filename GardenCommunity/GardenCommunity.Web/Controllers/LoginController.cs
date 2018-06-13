using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GardenCommunity.Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GardenCommunity.Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            var user = new User();
            return View(user);
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            return View();
        }
    }
}
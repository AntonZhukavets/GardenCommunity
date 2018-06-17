using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GardenCommunity.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserProvider userProvider;
        private readonly IRoleProvider roleProvider;
        private SelectList CreateRoleSelectList(int userId = 1)
        {
            var roles = roleProvider.GetRoles();
            var rolesDictionary = new Dictionary<int, string>();
            foreach (var role in roles)
            {
                rolesDictionary.Add(role.Id, role.Name);
            }
            return new SelectList(rolesDictionary, "Key", "Value", userId);
        }

        public UserController(IUserProvider userProvider, IRoleProvider roleProvider)
        {
            this.userProvider = userProvider;
            this.roleProvider = roleProvider;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult GetUsers()
        {
            var users = userProvider.GetUsers();
            return View(users);
        }

        [HttpGet]
        [Authorize]
        public IActionResult EditUser(int id)
        {
            var user = userProvider.GetUser(id);
            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                ConfirmPassword = user.Password,
                Role = user.Role
            };
           
            ViewBag.rolesViewModel = CreateRoleSelectList(user.Role.Id);
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult EditUser(UserViewModel user)
        {           
            ModelState.Remove("Role.Name");
            if (ModelState.IsValid)
            {                
                userProvider.EditUser(user);
                return RedirectToAction("GetMembers", "Member");
            }            
            ViewBag.rolesViewModel = CreateRoleSelectList(user.Role.Id);
            return View(user);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult RemoveUser(int id)
        {
            userProvider.RemoveUser(id);
            return RedirectToAction("GetUsers", "User");
        }

        
    }
}
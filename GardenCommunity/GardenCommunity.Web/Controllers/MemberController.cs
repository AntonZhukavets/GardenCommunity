using System;
using System.Collections.Generic;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.Common.Entities;
using GardenCommunity.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GardenCommunity.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberProvider memberProvider;
        public MemberController()
        {           
            this.memberProvider = new MemberProvider(new DBManagerMember());
        }

        [HttpGet]
        public IActionResult GetMembers(int? id)
        {
            var membersFiltr = new Dictionary<int, string>();
            membersFiltr.Add(1, "Active");
            membersFiltr.Add(2, "All");
            membersFiltr.Add(3, "Inactive");
            var filtrSlectList = new SelectList(membersFiltr, "Key", "Value");
            ViewBag.ddl_membersFiltr = filtrSlectList;
            if (!id.HasValue)
            {
                id = 1;
            }
            var members = memberProvider.GetMembers(id.Value);            
            return View(members);
        }

        [HttpGet]
        public IActionResult AddMember()
        {
            return View("AddMember");
        }

        [HttpPost]
        public IActionResult AddMember(Member member)
        {
            if (ModelState.IsValid)
            {
                memberProvider.AddMember(member);
                return RedirectToAction("GetMembers", "Member");
            }
            return View(member);
        }

        [HttpGet]
        public IActionResult EditMember(int id)
        {
            var member = memberProvider.GetMember(id);            
            return View("EditMember", member);
        }

        [HttpPost]
        public IActionResult EditMember(Member member)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(member.AreasForDelete))
                {

                    var strings = member.AreasForDelete.Split(';');
                    var areasForRemove = new List<int>();
                    foreach (var item in strings)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            areasForRemove.Add(Convert.ToInt32(item));
                        }
                    }
                    memberProvider.UpdateMember(member, areasForRemove);
                }
                else
                {
                    memberProvider.UpdateMember(member, null);
                }
                return RedirectToAction("GetMembers", "Member");

            }
            return View(member);
        }

        [HttpGet]
        public IActionResult GetMember(int id)
        {
            var member = memberProvider.GetMember(id);           
            return View("GetMember", member);
        }

        [HttpGet]
        public IActionResult RemoveMember(int id)
        {
            memberProvider.RemoveMember(id);
            return RedirectToAction("GetMembers", "Member");
        }
    }
}

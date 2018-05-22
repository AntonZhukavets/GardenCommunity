using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.DAL;
using GardenCommunity.Web.Mappers;
using GardenCommunity.Web.Models;

namespace GardenCommunity.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberProvider memberProvider;        
        public MemberController()
        {            
            var membersFiltr = new Dictionary<int, string>();
            membersFiltr.Add(1, "Active");
            membersFiltr.Add(2, "All");
            membersFiltr.Add(3, "Inactive");
            var filtrSlectList = new SelectList(membersFiltr, "Key", "Value");
            ViewBag.ddl_membersFiltr = filtrSlectList;
            this.memberProvider = new MemberProvider(new DBManagerMember());            
        }
        
        [HttpGet]
        public ActionResult GetMembers(int? id)
        {
            if(!id.HasValue)
            {
                id = 1;
            }
            var members = memberProvider.GetMembers(id.Value);
            var modelMembers = new List<Member>();
            foreach(var member in members)
            {
                modelMembers.Add(Mapper.FromDtoToMVCModelMap(member));
            }
            return View(modelMembers);            
        }    

        [HttpGet]
        public ActionResult AddMember()
        {
            return View("AddMember");
        }

        [HttpPost]
        public ActionResult AddMember(Member member)
        {
            if (ModelState.IsValid)
            {
                memberProvider.AddMember(Mapper.FromMVCModelToDtoMap(member));
                return RedirectToAction("GetMembers", "Member");
            }
            return View(member);
        }

        [HttpGet]
        public ActionResult EditMember(int id)
        {
            var member = memberProvider.GetMember(id);
            var modelMember = Mapper.FromDtoToMVCModelMap(member);
            return View("EditMember", modelMember);
        }        

        [HttpPost]
        public ActionResult EditMember(Member member)
        {
            if (ModelState.IsValid)
            {
                if(!string.IsNullOrEmpty(member.AreasForDelete))
                {

                    var strings = member.AreasForDelete.Split(';');
                    var areaIdList = new List<int>();
                    foreach(var item in strings)
                    {
                        if(!string.IsNullOrEmpty(item))
                        {
                            areaIdList.Add(Convert.ToInt32(item));
                        }                        
                    }
                }
                memberProvider.UpdateMember(Mapper.FromMVCModelToDtoMap(member));                
                return RedirectToAction("GetMembers", "Member");
                
            }
            return View(member);
        }

        [HttpGet]
        public ActionResult GetMember(int id)
        {
            var member = memberProvider.GetMember(id);
            var modelMember = Mapper.FromDtoToMVCModelMap(member);
            return View("GetMember", modelMember);
        }

        [HttpGet]
        public ActionResult RemoveMember(int id)
        {
            memberProvider.RemoveMember(id);
            return RedirectToAction("GetMembers", "Member");
        }
    }
}
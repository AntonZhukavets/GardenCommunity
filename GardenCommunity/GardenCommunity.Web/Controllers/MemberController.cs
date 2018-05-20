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
            this.memberProvider = new MemberProvider(new DBManagerMember());
        }
        
        [HttpGet]
        public ActionResult GetMembers()
        {
            var members = memberProvider.GetMembers();
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
                memberProvider.UpdateMember(Mapper.FromMVCModelToDtoMap(member));
                return RedirectToAction("GetMembers", "Member");
            }
            return View(member);
        }

        [HttpGet]
        public ActionResult RemoveMember(int id)
        {
            memberProvider.RemoveMember(id);
            return RedirectToAction("GetMembers", "Member");
        }
    }
}
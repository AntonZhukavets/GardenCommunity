using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.DAL;

namespace GardenCommunity.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberProvider memberProvider;
        public MemberController(IMemberProvider memberProvider)
        {
            this.memberProvider = new MemberProvider(new DBManagerMember());
        }
        
        [HttpGet]
        public ActionResult GetMembers()
        {
            var members = memberProvider.GetMembers(); 
            return View();
        }
    }
}
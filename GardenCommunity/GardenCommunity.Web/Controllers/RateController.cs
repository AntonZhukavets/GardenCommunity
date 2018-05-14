using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.DAL;
using GardenCommunity.Web.Mappers;
using GardenCommunity.Web.Models;

namespace GardenCommunity.Web.Controllers
{
    public class RateController : Controller
    {
        private readonly IRateProvider rateProvider;
        private readonly IMemberProvider memberProvider;
        public RateController()
        {
            rateProvider = new RateProvider(new DBManagerRate());
            memberProvider = new MemberProvider(new DBManagerMember());
        }
        [HttpGet]
        public ActionResult GetRates()
        {
            //var beginDate = new DateTime(2017, 1, 1);
            //var endDate = new DateTime(2018, 12, 31);
            //var rates = rateProvider.GetRates(beginDate, endDate);
            var members = memberProvider.GetMembers();
            var modelMembers = new List<Member>();
            //var modelRate = new List<Rate>();
            //if (members != null)
            //{                
                foreach(var member in members)
                {
                    modelMembers.Add(Mapper.FromDtoToMVCModelMap(member));
                }
            //}
            return View(modelMembers);
        }
    }
}
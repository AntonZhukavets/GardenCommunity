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
        public RateController()
        {
            rateProvider = new RateProvider(new DBManagerRate());
        }
        [HttpGet]
        public ActionResult GetRates()
        {
            var beginDate = new DateTime(2017, 1, 1);
            var endDate = new DateTime(2018, 12, 31);
            var rates = rateProvider.GetRates(beginDate, endDate);
            var modelRate = new List<Rate>();
            if (rates!=null)
            {                
                foreach(var rate in rates)
                {
                    modelRate.Add(Mapper.FromDtoToMVCModelMap(rate));
                }
            }
            return View(modelRate);
        }
    }
}
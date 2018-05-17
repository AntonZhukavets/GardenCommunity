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
            this.rateProvider = new RateProvider(new DBManagerRate());           
        }

        [HttpGet]
        public ActionResult GetRates()
        {
            var beginDate = new DateTime(2017, 1, 1);
            var endDate = new DateTime(2018, 12, 31);
            var rates = rateProvider.GetRates(beginDate, endDate);           
            var modelRates = new List<Rate>();
            if (rates != null)
            {
                foreach (var rate in rates)
                {
                    modelRates.Add(Mapper.FromDtoToMVCModelMap(rate));
                }
            }
            return View(modelRates);
        }

        [HttpGet]
        public ActionResult AddRate()
        {
            return View("AddRate");
        }

        [HttpPost]
        public ActionResult AddRate(Rate rate)
        {
            if(ModelState.IsValid)
            {
                rateProvider.AddRate(Mapper.FromMVCModelToDtoMap(rate));
                return RedirectToAction("GetRates", "Rate");
            }            
            return View(rate);
        }

        [HttpGet]
        public ActionResult EditRate(int id)
        {
            var rate = rateProvider.GetRate(id);
            var modelRate = Mapper.FromDtoToMVCModelMap(rate);
            return View("EditRate", modelRate);
        }

        [HttpPost]
        public ActionResult EditRate(Rate rate)
        {
            if (ModelState.IsValid)
            {
                rateProvider.UpdateRate(Mapper.FromMVCModelToDtoMap(rate));
                return RedirectToAction("GetRates", "Rate");
            }
            return View(rate);
        }

        [HttpGet]
        public ActionResult RemoveRate(int id)
        {
            rateProvider.RemoveRate(id);
            return RedirectToAction("GetRates", "Rate");
        }
    }
}
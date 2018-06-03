using System;
using System.Linq;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.Common.Entities;
using GardenCommunity.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GardenCommunity.Web.Controllers
{
    public class RateController : Controller
    {
        private readonly IRateProvider rateProvider;

        public RateController(IRateProvider rateProvider)
        {
            this.rateProvider = rateProvider;
        }

        [HttpGet]        
        public IActionResult GetRate(int id)
        {
            var rate = rateProvider.GetRate(id);            
            return Json(rate);
        }

        [HttpGet]
        public IActionResult GetRates()
        {            
            var beginDate = new DateTime(2017, 1, 1);
            var endDate = new DateTime(2018, 12, 31);
            var rates = rateProvider.GetRates(beginDate, endDate);
            return View(rates);
        }

        [HttpPost]        
        public JsonResult GetRates(DateTime dateOfPayment)
        {
            var beginDate = new DateTime(dateOfPayment.Year, dateOfPayment.Month, 1);
            var rates = rateProvider.GetRates(beginDate, DateTime.Now);
            return Json(rates);
        }

        [HttpGet]
        public IActionResult AddRate()
        {
            return View("AddRate");
        }

        [HttpPost]
        public IActionResult AddRate(Rate rate)
        {
            if (ModelState.IsValid)
            {
                rateProvider.AddRate(rate);
                return RedirectToAction("GetRates", "Rate");
            }
            return View(rate);
        }

        [HttpGet]
        public IActionResult EditRate(int id)
        {
            var rate = rateProvider.GetRate(id);            
            return View("EditRate", rate);
        }

        [HttpPost]
        public IActionResult EditRate(Rate rate)
        {
            if (ModelState.IsValid)
            {
                rateProvider.UpdateRate(rate);
                return RedirectToAction("GetRates", "Rate");
            }
            return View(rate);
        }

        [HttpGet]
        public IActionResult RemoveRate(int id)
        {
            rateProvider.RemoveRate(id);
            return RedirectToAction("GetRates", "Rate");
        }
    }
}
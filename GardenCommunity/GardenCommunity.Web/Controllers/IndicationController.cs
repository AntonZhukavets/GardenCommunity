using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.Common.Entities;
using GardenCommunity.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace GardenCommunity.Web.Controllers
{
    public class IndicationController : Controller
    {
        private readonly IIndicationProvider indicationProvider;
        public IndicationController()
        {
            this.indicationProvider = new IndicationProvider(new DBManagerIndication());
        }

        [HttpGet]
        public IActionResult GetIndications()
        {
            var indications = indicationProvider.GetIndications();
            return View("GetIndications", indications);
        }
    }
}
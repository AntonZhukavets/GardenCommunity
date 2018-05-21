using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.DAL;
using GardenCommunity.Web.Mappers;
using GardenCommunity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult GetIndications()
        {
            var indications = indicationProvider.GetIndications();
            var modelIndications = new List<Indication>();
            foreach(var indication in indications)
            {
                modelIndications.Add(Mapper.FromDtoToMVCModelMap(indication));
            }
            return View("GetIndications", modelIndications);
        }
    }
}
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
    public class AreaController : Controller
    {
        private readonly IAreaProvider areaProvider;
        public AreaController()
        {
            this.areaProvider = new AreaProvider(new DBManagerArea());
        }
        [HttpGet]
        public ActionResult GetAreas()
        {
            var areas = areaProvider.GetAreas();
            var modelAreas = new List<Area>();
            foreach(var area in areas)
            {
                modelAreas.Add(Mapper.FromDtoToMVCModelMap(area));
            }
            return View(modelAreas);
        }

        [HttpGet]
        public ActionResult AddArea()
        {
            return View("AddArea");
        }

        [HttpPost]
        public ActionResult AddArea(Area area)
        {
            if (ModelState.IsValid)
            {
                areaProvider.AddArea(Mapper.FromMVCModelToDtoMap(area));
                return RedirectToAction("GetAreas", "Area");
            }
            return View(area);
        }

        [HttpGet]
        public ActionResult EditArea(int id)
        {
            var area = areaProvider.GetArea(id);
            var modelArea = Mapper.FromDtoToMVCModelMap(area);
            return View("EditArea", modelArea);
        }

        [HttpPost]
        public ActionResult EditArea(Area area)
        {
            if (ModelState.IsValid)
            {
                areaProvider.UpdateArea(Mapper.FromMVCModelToDtoMap(area));
                return RedirectToAction("GetAreas", "Area");
            }
            return View(area);
        }

        [HttpGet]
        public ActionResult RemoveArea(int id)
        {
            areaProvider.RemoveArea(id);
            return RedirectToAction("GetAreas", "Area");
        }
    }
}
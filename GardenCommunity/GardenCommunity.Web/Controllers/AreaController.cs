using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.DAL;
using GardenCommunity.Web.Mappers;
using GardenCommunity.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GardenCommunity.Web.Controllers
{
    public class AreaController : Controller
    {
        private readonly IAreaProvider areaProvider;
        private readonly IMemberProvider memberProvider;
        public AreaController()
        {
            this.areaProvider = new AreaProvider(new DBManagerArea());
            this.memberProvider = new MemberProvider(new DBManagerMember());
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
        public ActionResult GetArea(int id)
        {
            var area = areaProvider.GetArea(id);
            var modelArea = Mapper.FromDtoToMVCModelMap(area);            
            return View(modelArea);
        }

        [HttpGet]
        public ActionResult AddArea()
        {            
            var members = memberProvider.GetActiveMembers();            
            if(members!=null)
            {
                var owners = new Dictionary<int, string>();
                owners.Add(0, string.Empty);
                foreach(var member in members)
                {
                    owners.Add(member.Id, member.LastName + " " + member.FirstName + " " + member.MiddleName);                    
                }
                var modelOwners = new SelectList(owners, "Key", "Value");
                ViewBag.owners = modelOwners;
            }                
            return View("AddArea");
        }

        [HttpPost]
        public ActionResult AddArea(Area area)
        {            
            if (ModelState.IsValid)
            {              
                var DTOArea = Mapper.FromMVCModelToDtoMap(area);
                if (area.MemberId != 0)
                {
                    var member = memberProvider.GetMember(area.MemberId);                    
                    DTOArea.Members.Add(member);
                }    
                else
                {
                    DTOArea.Members = null;
                }
                areaProvider.AddArea(DTOArea);
                return RedirectToAction("GetAreas", "Area");
            }
            return View(area);
        }

        [HttpGet]
        public ActionResult EditArea(int id)
        {
            var area = areaProvider.GetArea(id);
            var modelArea = Mapper.FromDtoToMVCModelMap(area);
            var members = memberProvider.GetActiveMembers();
            if (members != null)
            {
                var owners = new Dictionary<int, string>();
                owners.Add(0, string.Empty);
                foreach (var member in members)
                {
                    owners.Add(member.Id, member.LastName + " " + member.FirstName + " " + member.MiddleName);                                    
                }
                var selectedItem = modelArea.Members.Last();               
                var selected = 0;
                if (selectedItem != null )
                {
                    selected = selectedItem.Id;
                }                
                var modelOwners = new SelectList(owners, "Key", "Value", selected);           
                ViewBag.owners = modelOwners;
                
            }
            
            return View("EditArea", modelArea);
        }


        [HttpPost]
        public ActionResult EditArea(Area area)
        {
            if (ModelState.IsValid)
            {
                //if(area.MemberId!=0)
                //{
                //    area.IsPrivate = true;
                //}
                areaProvider.UpdateArea(Mapper.FromMVCModelToDtoMap(area), area.MemberId);
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
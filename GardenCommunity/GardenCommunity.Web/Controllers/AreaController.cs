using System.Collections.Generic;
using System.Linq;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.Common.Entities;
using GardenCommunity.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult GetAreas()
        {
            var areas = areaProvider.GetAreas();           
            return View(areas);
        }

        [HttpGet]
        public IActionResult GetArea(int id)
        {
            var area = areaProvider.GetArea(id);           
            return View(area);
        }

        [HttpGet]
        public IActionResult AddArea()
        {
            var members = memberProvider.GetActiveMembers();
            var owners = new Dictionary<int, string>();
            owners.Add(0, string.Empty);
            foreach (var member in members)
            {
                owners.Add(member.Id, member.LastName + " " + member.FirstName + " " + member.MiddleName);
            }
            var modelOwners = new SelectList(owners, "Key", "Value");
            ViewBag.owners = modelOwners;            
            return View("AddArea");
        }

        [HttpPost]
        public IActionResult AddArea(Area area)
        {
            if (ModelState.IsValid)
            {                
                if (area.MemberId != 0)
                {
                    var member = memberProvider.GetMember(area.MemberId);
                    area.Members.Add(member);
                }
                else
                {
                    area.Members = null;
                }
                areaProvider.AddArea(area);
                return RedirectToAction("GetAreas", "Area");
            }
            return View(area);
        }

        [HttpGet]
        public IActionResult EditArea(int id)
        {
            var area = areaProvider.GetArea(id);           
            var members = memberProvider.GetActiveMembers();
            var owners = new Dictionary<int, string>();
            owners.Add(0, string.Empty);
            foreach (var member in members)
            {
                owners.Add(member.Id, member.LastName + " " + member.FirstName + " " + member.MiddleName);
            }
            var selectedItem = area.Members.Last();
            var selected = 0;
            if (selectedItem != null)
            {
                selected = selectedItem.Id;
            }
            ViewBag.owners = new SelectList(owners, "Key", "Value", selected);
            return View("EditArea", area);
        }


        [HttpPost]
        public IActionResult EditArea(Area area)
        {
            if (ModelState.IsValid)
            {
                areaProvider.UpdateArea(area, area.MemberId);
                return RedirectToAction("GetAreas", "Area");
            }
            return View(area);
        }

        [HttpGet]
        public IActionResult RemoveArea(int id)
        {
            areaProvider.RemoveArea(id);
            return RedirectToAction("GetAreas", "Area");
        }
    }
}
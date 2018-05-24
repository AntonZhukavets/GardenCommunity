﻿using System;
using System.Collections.Generic;
using System.Linq;
using GardenCommunity.DAL.Entities;
using GardenCommunity.DAL.Interfaces;

namespace GardenCommunity.DAL
{
    public class DBManagerArea : IDBManagerArea
    {
        public IEnumerable<Area> GetAreas()
        {
            using (var db = new GardenCommunityDB())
            {
                return db.Areas.Include("Members").ToList();
            }
        }

        public IEnumerable<Area> GetAreasByMemberId(int memberId)
        {
            using (var db = new GardenCommunityDB())
            {
                var member = db.Members.Include("Areas").Where(x => x.Id == memberId).FirstOrDefault();                
                if (member != null && member.Areas.Count > 0)
                {
                    var membersAreas = new List<Area>();
                    membersAreas.AddRange(member.Areas);
                    foreach (var area in member.Areas)
                    {
                        var childAreas = db.Areas.Where(x => x.ParentAreaId.Value == area.Id).ToList();
                        membersAreas.AddRange(childAreas);
                    }
                    return membersAreas;
                }
                return null;
            }
        }

        public Area GetArea(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                return db.Areas.Include("Members").Where(x => x.Id == id).First();
            }
        }

        public void AddArea(Area area)
        {
            if (area == null)
            {
                throw new ArgumentNullException("area");
            }
            using (var db = new GardenCommunityDB())
            {
                if(area.Members!=null)
                {
                    foreach(var member in area.Members)
                    {                       
                        db.Members.Attach(member);
                    }
                }
                db.Areas.Add(area);
                db.SaveChanges();
            }
            
        }

        public void UpdateArea(Area area, int memberId)
        {           
            if (area == null)
            {
                throw new ArgumentNullException("area");
            }
            using (var db = new GardenCommunityDB())
            {
                var targetArea = db.Areas.Include("Members").Where(x => x.Id == area.Id).First();
                if (targetArea != null)
                {
                    targetArea.Square = area.Square;
                    targetArea.IsPrivate = area.IsPrivate;
                    targetArea.HasElectricity = area.HasElectricity;
                    targetArea.ParentAreaId = area.ParentAreaId;
                    //var member = targetArea.Members.FirstOrDefault(x => x.IsActiveMember);
                    if (memberId != 0)
                    {
                        //if (member != null)
                        //{
                        //    targetArea.Members.Remove(member);
                        //}
                        var newMember = db.Members.First(x => x.Id == memberId);
                        targetArea.Members.Add(newMember);
                        db.Members.Attach(newMember);
                    }                   
                    db.SaveChanges();
                }
            }
        }

        public void RemoveArea(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var targetArea = db.Areas.Find(id);
                if (targetArea != null)
                {
                    db.Areas.Remove(targetArea);
                    db.SaveChanges();
                }
            }
        }
    }
}

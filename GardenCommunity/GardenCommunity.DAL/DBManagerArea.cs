using System;
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
                return db.Areas.ToList();
            }

        }

        public IEnumerable<Area> GetAreasByMemberId(int memberId)
        {
            using (var db = new GardenCommunityDB())
            {
                var member = db.Members.Include("Areas").Where(x => x.Id == memberId).FirstOrDefault();
                var areaIdList = new List<int>();
                if (member != null && member.Areas.Count > 0)
                {
                    var membersAreas = new List<Area>();
                    membersAreas.AddRange(member.Areas);

                    foreach (var area in member.Areas)
                    {
                        var additionalAreas = db.Areas.Where(x => x.AdditionalAreaId.Value == area.Id).ToList();
                        membersAreas.AddRange(additionalAreas);
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
                return db.Areas.Find(id);
            }
        }

        public void AddArea(Area area)
        {
            if (area != null)
            {
                using (var db = new GardenCommunityDB())
                {
                    db.Areas.Add(area);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateArea(Area area)
        {
            using (var db = new GardenCommunityDB())
            {
                var targetArea = db.Areas.Find(area.Id);
                if (targetArea != null)
                {
                    targetArea.Square = area.Square;
                    targetArea.IsPrivate = area.IsPrivate;
                    targetArea.HasElectricity = area.HasElectricity;
                    targetArea.AdditionalArea = area.AdditionalArea;
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
                }
            }
        }
    }
}

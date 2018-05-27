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
                //db.MembersAreas.Include("Area").Include("Member").Where(x=>x.MemberId == id).ToList() ??
                var areas = db.Areas.Include("MembersAreas").ToList() ?? new List<Area>(); //example
                //if (areas != null)
                //{
                    foreach (var area in areas)
                    {
                        if(area.MembersAreas!=null)
                        foreach (var memberArea in area.MembersAreas)
                        {
                             memberArea.Member = db.Members.First(x => x.Id == memberArea.MemberId);
                        }
                    }
                //}
                return areas;                
            }
        }

        public IEnumerable<Area> GetAreasByMemberId(int memberId)
        {
            //using (var db = new GardenCommunityDB())
            //{
            //    var member = db.Members.Include("MembersAreas").Where(x => x.Id == memberId).FirstOrDefault();
            //    if (member != null && member.MembersAreas.Count > 0)
            //    {
            //        var membersAreas = new List<Area>();
            //        membersAreas.AddRange(member.MembersAreas);
            //        foreach (var area in member.Areas)
            //        {
            //            var childAreas = db.Areas.Where(x => x.ParentAreaId.Value == area.Id).ToList();
            //            membersAreas.AddRange(childAreas);
            //        }
            //        return membersAreas;
            //    }
            //    return null;
            //}
            return null;
        }

        public Area GetArea(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var area = db.Areas.Include("MembersAreas").Where(x => x.Id == id).First();                
                foreach (var memberArea in area.MembersAreas)
                {
                    memberArea.Member = db.Members.First(x => x.Id == memberArea.MemberId);
                }
                return area;
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
                if (area.MembersAreas != null)
                {
                    foreach (var memberArea in area.MembersAreas)
                    {
                        db.Members.Attach(memberArea.Member);
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
                var targetArea = db.Areas.Include("MembersAreas").First(x => x.Id == area.Id);
                if (targetArea != null)
                {
                    targetArea.Square = area.Square;
                    targetArea.IsPrivate = area.IsPrivate;
                    targetArea.HasElectricity = area.HasElectricity;
                    targetArea.ParentAreaId = area.ParentAreaId;
                    var member = db.Members.Include("MembersAreas").First(x => x.Id == memberId);
                    member.MembersAreas.Add(new MembersAreas()
                    {
                        Member = member,
                        MemberId = member.Id,
                        Area = targetArea,
                        AreaId = targetArea.Id
                    });
                    ////var member = targetArea.Members.FirstOrDefault(x => x.IsActiveMember);
                    //if (memberId != 0)
                    //{
                    //    //if (member != null)
                    //    //{
                    //    //    targetArea.Members.Remove(member);
                    //    //}
                    //    var newMember = db.Members.First(x => x.Id == memberId);
                    //    //targetArea.Members.Add(newMember);
                    //    db.Members.Attach(newMember);
                    //}
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

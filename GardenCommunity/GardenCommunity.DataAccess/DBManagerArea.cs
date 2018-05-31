using GardenCommunity.DataAccess.Entities;
using GardenCommunity.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GardenCommunity.DataAccess
{
    public class DBManagerArea : IDBManagerArea
    {        
        private const int gardenCommunityId= 1;
        public int AddArea(Area area)
        {
            var Area = area ?? throw new ArgumentNullException("area");
            using (var db = new GardenCommunityContext())
            {
                db.Areas.Add(area);
                foreach(var memberArea in area.MembersAreas)
                {
                    db.Members.Attach(memberArea.Member);
                    db.MembersAreas.Add(memberArea);
                }
                db.SaveChanges();
            }
            return area.Id;    
        }

        public Area GetArea(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var area = db.Areas.First(x => x.Id == id);
                var membersAreas = db.MembersAreas.Include(x=>x.Member).Where(x => x.AreaId == id).ToList() ?? new List<MembersAreas>();
                area.MembersAreas = membersAreas;
                return area;
            }
        }

        public IEnumerable<Area> GetAreas()
        {
            using (var db = new GardenCommunityContext())
            {
                var areas = db.Areas.ToList();
                //var membersAreas = db.MembersAreas.Include("Area").Include("Member").Select(x => x.Area).ToList();
                foreach(var area in areas)
                {
                    area.MembersAreas = db.MembersAreas.Include(x=>x.Member).Where(x => x.AreaId == area.Id).ToList();
                }
                return areas;
            }
        }

        public IEnumerable<Area> GetAreasByMemberId(int memberId)
        {
            throw new NotImplementedException();
        }

        public int RemoveArea(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var area = db.Areas.First(x => x.Id == id);
                db.Areas.Remove(area);
                db.SaveChanges();
                return area.Id;
            }            
        }

        public int UpdateArea(Area area, int memberId)
        {
            var Area = area ?? throw new ArgumentNullException("area");
            using (var db = new GardenCommunityContext())
            {
                var updatableArea = db.Areas.First(x => x.Id == area.Id);
                updatableArea.Square = area.Square;
                updatableArea.IsPrivate = area.IsPrivate;
                updatableArea.HasElectricity = area.HasElectricity;
                updatableArea.ParentAreaId = area.ParentAreaId;
                if(memberId != 0)
                {
                    var member = db.Members.First(x => x.Id == memberId);
                    db.MembersAreas.Add(new MembersAreas()
                    {
                        Member = member,
                        MemberId = member.Id,
                        Area = area,
                        AreaId = area.Id
                    });
                }
                db.SaveChanges();
            }
            return area.Id;
        }
    }
}

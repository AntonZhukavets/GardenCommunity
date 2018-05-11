using System;
using System.Collections.Generic;
using System.Linq;
using GardenCommunity.DAL.Entities;
using GardenCommunity.DAL.Interfaces;

namespace GardenCommunity.DAL
{
    public class DBManagerMember : IDBManagerMember
    {
        public IEnumerable<Member> GetMembers()
        {
            using (var db = new GardenCommunityDB())
            {
                return db.Members.ToList();
            }
        }

        public Member GetMember(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var member = db.Members.Where(x => x.Id == id).First();
                return member;
            }
        }

        public void AddMember(Member member)
        {
            using (var db = new GardenCommunityDB())
            {
                db.Members.Add(member);
                db.SaveChanges();
            }
        }

        public void UpdateMember(Member member)
        {
            using (var db = new GardenCommunityDB())
            {
                var updatableMember = db.Members.Where(x => x.Id == member.Id).First();
                updatableMember.FirstName = member.FirstName;
                updatableMember.LastName = member.LastName;
                updatableMember.MiddleName = member.MiddleName;
                updatableMember.Address = member.Address;
                updatableMember.Phone = member.Phone;
                updatableMember.IsActiveMember = member.IsActiveMember;
                updatableMember.Payments = member.Payments;
                updatableMember.Areas = member.Areas;
                db.SaveChanges();
            }
        }

        public void RemoveMember(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var deletableMember = db.Members.Where(x => x.Id == id).First();
                db.Members.Remove(deletableMember);
                db.SaveChanges();
            }
        }

        public IEnumerable<Member> GetMembersByAreaId(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var members = new List<Member>();
                int mainAreaId = 0;
                var area = db.Areas.Include("Members").Where(x => x.Id == id).FirstOrDefault();
                //if (area.Members.Count != 0)
                //{
                //    members.AddRange(area.Members);
                //}
                //if (area.AdditionalAreaId != null)
                //{
                //    mainAreaId = area.AdditionalAreaId.Value;
                //    area = db.Areas.Include("Members").Where(x => x.Id == mainAreaId).FirstOrDefault();
                //    members.AddRange(area.Members);
                //}             
                return members;
            }
        }
    }
}

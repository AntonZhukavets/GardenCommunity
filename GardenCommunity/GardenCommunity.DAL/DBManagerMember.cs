using System;
using System.Collections.Generic;
using System.Linq;
using GardenCommunity.DAL.Entities;
using GardenCommunity.DAL.Interfaces;

namespace GardenCommunity.DAL
{
    public class DBManagerMember : IDBManagerMember
    {
        public IEnumerable<Member> GetMembers(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                switch (id)
                {
                    case 1:
                        return db.Members.Include("Areas").Where(x=>x.IsActiveMember==true).ToList();                       
                    case 2:
                        return db.Members.Include("Areas").ToList();
                    case 3:
                        return db.Members.Include("Areas").Where(x => x.IsActiveMember == false).ToList();
                    default:
                        return db.Members.Include("Areas").ToList();
                }
                
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
            if (member == null)
            {
                throw new ArgumentNullException("member");
            }
            using (var db = new GardenCommunityDB())
            {
                db.Members.Add(member);
                db.SaveChanges();
            }
        }

        public void UpdateMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException("member");
            }
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
                deletableMember.IsActiveMember = false;
                db.SaveChanges();
            }
        }

        public IEnumerable<Member> GetMembersByAreaId(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var members = new List<Member>();
                var area = db.Areas.Include("Members").Where(x => x.Id == id).First();
                if(area.Members!=null)
                {
                    members.AddRange(area.Members);
                }
                if(area.ParentAreaId!=null)
                {
                    members.AddRange(GetMembersByAreaId(area.ParentAreaId.Value));
                }                                          
                return members;
            }
        }

        public IEnumerable<Member> GetActiveMembers()
        {
            using (var db = new GardenCommunityDB())
            {
                return db.Members.Where(x => x.IsActiveMember == true).ToList();
            }
        }
    }
}

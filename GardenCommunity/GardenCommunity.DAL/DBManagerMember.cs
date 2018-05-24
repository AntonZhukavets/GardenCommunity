﻿using System;
using System.Collections.Generic;
using System.Linq;
using GardenCommunity.DAL.Entities;
using GardenCommunity.DAL.Interfaces;

namespace GardenCommunity.DAL
{
    public class DBManagerMember : IDBManagerMember
    {
        private const int gardenCommunityId= 1;
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
                var member = db.Members.Include("Areas").First(x => x.Id == id);
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

        public void UpdateMember(Member member, IEnumerable<int> areasForRemove)
        {
            if (member == null)
            {
                throw new ArgumentNullException("member");
            }
            using (var db = new GardenCommunityDB())
            {                
                var updatableMember = db.Members.Include("Areas").Where(x => x.Id == member.Id).First();
                updatableMember.FirstName = member.FirstName;
                updatableMember.LastName = member.LastName;
                updatableMember.MiddleName = member.MiddleName;
                updatableMember.Address = member.Address;
                updatableMember.Phone = member.Phone;
                updatableMember.IsActiveMember = member.IsActiveMember;                
                if (areasForRemove != null)
                {
                    var gardenCommunity = db.Members.Include("Areas").First(x => x.Id == gardenCommunityId);
                    foreach (var id in areasForRemove)
                    {
                        var area = updatableMember.Areas.First(x => x.Id == id);                        
                        //updatableMember.Areas.First(x => x.Id == id).IsPrivate = false;
                        area.IsPrivate = false;
                        //updatableMember.Areas.Remove(db.Areas.First(x => x.Id == id));
                        gardenCommunity.Areas.Add(area);                        
                        db.Areas.Attach(area);
                    }
                }
                db.SaveChanges();
            }
        }

        public void RemoveMember(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var deletableMember = db.Members.Include("Areas").Where(x => x.Id == id).First();
                deletableMember.IsActiveMember = false;
                foreach(var area in deletableMember.Areas)
                {
                    area.IsPrivate = false;
                }
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

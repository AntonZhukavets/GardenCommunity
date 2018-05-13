﻿using System;
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
                return db.Members.Include("Areas").ToList();
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
                db.Members.Remove(deletableMember);
                db.SaveChanges();
            }
        }

        public Member GetMemberByAreaId(int id)
        {
            using (var db = new GardenCommunityDB())
            {                
                var area = db.Areas.Include("Member").Where(x => x.Id == id).First();
                int parentAreaId;
                if (area.MemberId==null)
                {
                    parentAreaId = area.ParentAreaId.Value;
                    return GetMemberByAreaId(parentAreaId);
                }                            
                return area.Member;
            }
        }
    }
}

using GardenCommunity.DataAccess.Entities;
using GardenCommunity.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GardenCommunity.DataAccess
{
    public class DBManagerMember : IDBManagerMember
    {
        private Member member;
        private const int gardenCommunityId = 1;
        public int AddMember(Member member)
        {    
            this.member = member ?? throw new ArgumentNullException("member");
            using (var db = new GardenCommunityContext())
            {
                db.Members.Add(this.member);
                db.SaveChanges();
            }
            return member.Id;
        }

        public IEnumerable<Member> GetActiveMembers() 
        {
            using (var db = new GardenCommunityContext())
            {
                return db.Members.Where(x => x.IsActiveMember == true).ToList() ?? new List<Member>();
            }
        }

        public Member GetMember(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                //?  ??? db.MembersAreas.Include(x => x.Member).Include(x => x.Area).Where(x => x.MemberId == id).Select(x=>x.Member);
                var member = db.Members.First(x => x.Id == id);
                // db.Members.Include(x=>x.MembersAreas).ThenInclude(x=>x.)
                member.MembersAreas = db.MembersAreas.Include(x => x.Area).Where(x => x.MemberId == id).ToList() ?? new List<MembersAreas>();
                return member;
            }
        }

        public IEnumerable<Member> GetMembers(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                switch (id)
                {
                    case 1:
                        var activeMembers = db.Members.Where(x => x.IsActiveMember == true).ToList() ?? new List<Member>();
                        return activeMembers;
                    case 2:
                        var members = db.Members.ToList() ?? new List<Member>();
                        return members;
                    case 3:
                        var inActiveMembers = db.Members.Where(x => x.IsActiveMember == false).ToList() ?? new List<Member>();
                        return inActiveMembers;
                    default:
                        var defaultMembers = db.Members.ToList() ?? new List<Member>();
                        return defaultMembers;
                }

            }
        }

        public IEnumerable<Member> GetMembersByAreaId(int id)
        {
            throw new NotImplementedException();
        }

        public int RemoveMember(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var gardenCommunity = db.Members.Include("MembersAreas").First(x => x.Id == gardenCommunityId);
                var member = db.Members.First(x => x.Id == id);
                member.IsActiveMember = false;
                foreach (var memberArea in member.MembersAreas)
                {
                    gardenCommunity.MembersAreas.Add(new MembersAreas()
                    {
                        Member = gardenCommunity,
                        MemberId = gardenCommunity.Id,
                        Area = memberArea.Area,
                        AreaId = memberArea.AreaId
                    });
                }
                db.SaveChanges();
                return member.Id;
            }            
        }

        public int UpdateMember(Member member, IEnumerable<int> areasForRemove)
        {
            this.member = member ?? throw new ArgumentNullException("member");            
            using (var db = new GardenCommunityContext())
            {
                var updatableMember = db.Members.Include("MembersAreas").First(x => x.Id == member.Id);
                updatableMember.FirstName = member.FirstName;
                updatableMember.LastName = member.LastName;
                updatableMember.MiddleName = member.MiddleName;
                updatableMember.Address = member.Address;
                updatableMember.Phone = member.Phone;
                updatableMember.IsActiveMember = member.IsActiveMember;
                if (areasForRemove != null)
                {
                    var gardenCommunity = db.Members.Include("MembersAreas").First(x => x.Id == gardenCommunityId);
                    foreach (var id in areasForRemove)
                    {
                        var memberArea = db.MembersAreas.First(x => x.AreaId == id);
                        gardenCommunity.MembersAreas.Add(new MembersAreas()
                        {
                            Area = memberArea.Area,
                            Member = gardenCommunity,
                            AreaId = memberArea.AreaId,
                            MemberId = gardenCommunity.Id
                        });
                    }
                }
                db.SaveChanges();
                return member.Id;
            }
        }

        public Member GetMemberWithPayments(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var member = db.Members.Include(x => x.Payments).First(x => x.Id == id);
                return member;
            }
        }
    }
}

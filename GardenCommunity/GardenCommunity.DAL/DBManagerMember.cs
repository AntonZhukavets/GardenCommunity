using System;
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
                        var activeMembers = db.Members.Where(x => x.IsActiveMember == true).ToList();                        
                        return activeMembers;
                    case 2:
                        var members = db.Members.ToList();                        
                        return members;
                    case 3:
                        var inActiveMembers = db.Members.Where(x => x.IsActiveMember == false).ToList();                       
                        return inActiveMembers;
                    default:
                        var defaultMembers = db.Members.ToList();                       
                        return defaultMembers;
                }
                
            }
        }

        public Member GetMember(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var member = db.Members.Include("MembersAreas").First(x => x.Id == id);
                //foreach (var memberArea in member.MembersAreas)
                //{
                //    //memberArea.Area = db.Areas.First(x => x.Id == memberArea.AreaId);
                //    var areas = db.MembersAreas.Include("Area").Where(x => x.AreaId == memberArea.AreaId).ToList();
                //    if (areas.Last().MemberId == id)
                //    {
                //        memberArea.Area = .Add(new MembersAreas()
                //        {
                //            Member = member,
                //            MemberId = member.Id,
                //            Area = areas.Last().Area,
                //            AreaId = areas.Last().AreaId
                //        });
                //    }

                //}   
                var areaList = new List<Area>();
                foreach (var memberArea in member.MembersAreas)
                {
                    var areas = db.MembersAreas.Include("Area").Where(x => x.AreaId == memberArea.AreaId).ToList();
                    if (areas.Last().MemberId == member.Id)
                    {
                        areaList.Add(areas.Last().Area);
                    }
                }
                //?????
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
                            AreaId=memberArea.AreaId,
                            MemberId=gardenCommunity.Id
                        });                        
                    }
                }
                db.SaveChanges();
            }
        }

        public void RemoveMember(int id)
        {
            using (var db = new GardenCommunityDB())
            {
                var deletableMember = db.Members.Include("MembersAreas").First(x => x.Id == id);
                var gardenCommunity = db.Members.Include("MembersAreas").First(x => x.Id == gardenCommunityId);
                deletableMember.IsActiveMember = false;
                foreach (var memberArea in deletableMember.MembersAreas)
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
            }
        }

        public IEnumerable<Member> GetMembersByAreaId(int id)
        {
            //using (var db = new GardenCommunityDB())
            //{
            //    var members = new List<Member>();
            //    var area = db.Areas.Include("Members").Where(x => x.Id == id).First();
            //    if(area.Members!=null)
            //    {
            //        members.AddRange(area.Members);
            //    }
            //    if(area.ParentAreaId!=null)
            //    {
            //        members.AddRange(GetMembersByAreaId(area.ParentAreaId.Value));
            //    }                                          
            //    return members;
            //}
            return null;
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

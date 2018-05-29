using GardenCommunity.Business.Interfaces;
using GardenCommunity.Common.Entities;
using GardenCommunity.Common.Mappers;
using GardenCommunity.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace GardenCommunity.Business.Providers
{
    public class MemberProvider : IMemberProvider
    {
        private readonly IDBManagerMember dBManagerMember;
        public MemberProvider(IDBManagerMember dBManagerMember)
        {
            this.dBManagerMember = dBManagerMember;
        }
        public int AddMember(Member member)
        {
            var Member = member ?? throw new ArgumentNullException("member");
            return dBManagerMember.AddMember(Mapper.FromBusinessToDataAccessMap(member));
        }

        public IEnumerable<Member> GetActiveMembers()
        {
            var members = new List<Member>();
            var dALMembers = dBManagerMember.GetActiveMembers();
            foreach(var dALMember in dALMembers)
            {
                members.Add(Mapper.FromDataAccessToBusinessMap(dALMember));
            }
            return members;
        }

        public Member GetMember(int id)
        {
            var member = dBManagerMember.GetMember(id);
            return Mapper.FromDataAccessToBusinessMap(member);
        }

        public IEnumerable<Member> GetMembers(int id)
        {
            var members = new List<Member>();
            var dALMembers = dBManagerMember.GetMembers(id);
            foreach (var dALMember in dALMembers)
            {
                members.Add(Mapper.FromDataAccessToBusinessMap(dALMember));
            }
            return members;
        }

        public IEnumerable<Member> GetMembersByAreaId(int id)
        {
            var members = new List<Member>();
            var dALMembers = dBManagerMember.GetMembersByAreaId(id);
            foreach (var dALMember in dALMembers)
            {
                members.Add(Mapper.FromDataAccessToBusinessMap(dALMember));
            }
            return members;
        }

        public int RemoveMember(int id)
        {
            return dBManagerMember.RemoveMember(id);
        }

        public int UpdateMember(Member member, IEnumerable<int> areasForRemove)
        {
            var Member = member ?? throw new ArgumentNullException("member");
            return dBManagerMember.UpdateMember(Mapper.FromBusinessToDataAccessMap(member), areasForRemove);
        }
    }
}

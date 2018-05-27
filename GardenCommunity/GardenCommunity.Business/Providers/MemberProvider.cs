using GardenCommunity.Business.Interfaces;
using GardenCommunity.Common.Entities;
using GardenCommunity.Common.Mappers;
using GardenCommunity.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetMembers(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetMembersByAreaId(int id)
        {
            throw new NotImplementedException();
        }

        public int RemoveMember(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateMember(Member member, IEnumerable<int> areasForRemove)
        {
            throw new NotImplementedException();
        }
    }
}

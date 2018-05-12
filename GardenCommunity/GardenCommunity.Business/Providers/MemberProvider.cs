using System;
using System.Collections.Generic;
using System.Linq;
using GardenCommunity.Business.DTO;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Mappers;
using GardenCommunity.DAL.Interfaces;

namespace GardenCommunity.Business.Providers
{
    public class MemberProvider : IMemberProvider
    {
        private readonly IDBManagerMember dBManagerMember;        
        public MemberProvider(IDBManagerMember dBManagerMember)
        {
            this.dBManagerMember = dBManagerMember;
        }

        public void AddMember(Member member)
        {
            dBManagerMember.AddMember(Mapper.MemberFromDtoToDalMap(member));
        }

        public Member GetMember(int id)
        {
            throw new NotImplementedException();
        }

        public Member GetMemberByAreaId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetMembers()
        {
            throw new NotImplementedException();
        }

        public void RemoveMember(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMember(Member member)
        {
            dBManagerMember.UpdateMember(Mapper.MemberFromDtoToDalMap(member));
        }
    }
}

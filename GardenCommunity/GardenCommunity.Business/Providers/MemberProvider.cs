using System;
using System.Collections.Generic;
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
            if(member==null)
            {
                throw new ArgumentNullException("member");
            }
            dBManagerMember.AddMember(Mapper.MemberFromDtoToDalMap(member));
        }

        public Member GetMember(int id)
        {
            var member = dBManagerMember.GetMember(id);
            return Mapper.MemberFromDalToDtoMap(member);
        }

        public Member GetMemberByAreaId(int id)
        {
            var member = dBManagerMember.GetMemberByAreaId(id);
            return Mapper.MemberFromDalToDtoMap(member);
        }

        public IEnumerable<Member> GetMembers()
        {            
            var dALMembers = dBManagerMember.GetMembers();
            if (dALMembers != null)
            {
                var members = new List<Member>();
                foreach (var dALMember in dALMembers)
                {
                    members.Add(Mapper.MemberFromDalToDtoMap(dALMember));
                }
                return members;
            }
            return null;
        }

        public void RemoveMember(int id)
        {
            dBManagerMember.RemoveMember(id);
        }

        public void UpdateMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException("member");
            }
            dBManagerMember.UpdateMember(Mapper.MemberFromDtoToDalMap(member));
        }
    }
}

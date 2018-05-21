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
            dBManagerMember.AddMember(Mapper.FromDtoToDalMap(member));
        }

        public Member GetMember(int id)
        {
            var member = dBManagerMember.GetMember(id);
            return Mapper.FromDalToDtoMap(member);
        }

        public IEnumerable<Member> GetMembersByAreaId(int id)
        {
            var dALMembers = dBManagerMember.GetMembersByAreaId(id);
            if (dALMembers != null)
            {
                var members = new List<Member>();
                foreach (var dALMember in dALMembers)
                {
                    members.Add(Mapper.FromDalToDtoMap(dALMember));
                }
                return members;
            }
            return null;
        }

        public IEnumerable<Member> GetMembers(int id)
        {            
            var dALMembers = dBManagerMember.GetMembers(id);
            if (dALMembers != null)
            {
                var members = new List<Member>();
                foreach (var dALMember in dALMembers)
                {
                    members.Add(Mapper.FromDalToDtoMap(dALMember));
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
            dBManagerMember.UpdateMember(Mapper.FromDtoToDalMap(member));
        }

        public IEnumerable<Member> GetActiveMembers()
        {
            var dALMembers = dBManagerMember.GetActiveMembers();
            if (dALMembers != null)
            {
                var members = new List<Member>();
                foreach (var dALMember in dALMembers)
                {
                    members.Add(Mapper.FromDalToDtoMap(dALMember));
                }
                return members;
            }
            return null;            
        }
    }
}

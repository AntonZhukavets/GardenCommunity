using System;
using System.Collections.Generic;
using GardenCommunity.DAL.Entities;

namespace GardenCommunity.DAL.Interfaces
{
    public interface IDBManagerMember
    {
        void AddMember(Member member);
        void UpdateMember(Member member);
        void RemoveMember(int id);
        Member GetMember(int id);        
        Member GetMemberByAreaId(int id);
        IEnumerable<Member> GetMembers();
    }
}

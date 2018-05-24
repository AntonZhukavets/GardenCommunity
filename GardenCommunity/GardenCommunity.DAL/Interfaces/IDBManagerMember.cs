using System;
using System.Collections.Generic;
using GardenCommunity.DAL.Entities;

namespace GardenCommunity.DAL.Interfaces
{
    public interface IDBManagerMember
    {
        void AddMember(Member member);
        void UpdateMember(Member member, IEnumerable<int> areasForRemove);
        void RemoveMember(int id);
        Member GetMember(int id);        
        IEnumerable<Member> GetMembersByAreaId(int id);
        IEnumerable<Member> GetMembers(int id);
        IEnumerable<Member> GetActiveMembers();
    }
}

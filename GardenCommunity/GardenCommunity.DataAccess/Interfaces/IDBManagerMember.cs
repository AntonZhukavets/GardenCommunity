using GardenCommunity.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace GardenCommunity.DataAccess.Interfaces
{
    public interface IDBManagerMember
    {
        int AddMember(Member member);
        int UpdateMember(Member member, IEnumerable<int> areasForRemove);
        int RemoveMember(int id);
        Member GetMember(int id);
        IEnumerable<Member> GetMembersByAreaId(int id);
        IEnumerable<Member> GetMembers(int id);
        IEnumerable<Member> GetActiveMembers();
    }
}

using GardenCommunity.Common.Entities;
using System.Collections.Generic;

namespace GardenCommunity.Business.Interfaces
{
    public interface IMemberProvider
    {
        int AddMember(Member member);
        int UpdateMember(Member member, IEnumerable<int> areasForRemove);
        int RemoveMember(int id);
        IEnumerable<Member> GetMembers(int id);
        IEnumerable<Member> GetActiveMembers();
        IEnumerable<Member> GetMembersByAreaId(int id);
        Member GetMember(int id);
    }
}

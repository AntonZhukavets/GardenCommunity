using GardenCommunity.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GardenCommunity.Business.Interfaces
{
    public interface IMemberProvider
    {
        void AddMember(Member member);
        void UpdateMember(Member member);
        void RemoveMember(int id);
        IEnumerable<Member> GetMembers();
        Member GetMember(int id);
        Member GetMemberByAreaId(int id);
    }
}

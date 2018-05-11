using GardenCommunity.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenCommunity.Business
{
    public interface IDataProvider
    {
        IEnumerable<Member> GetMembers();
        void AddMember(Member member);
        void UpdateMember(Member member);
        void RemoveMember(int id);       
    }
}

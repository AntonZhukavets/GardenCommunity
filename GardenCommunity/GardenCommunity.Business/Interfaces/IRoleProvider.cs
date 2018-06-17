using GardenCommunity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardenCommunity.Business.Interfaces
{
    public interface IRoleProvider
    {
        Role GetRole(int id);

        Role GetRole(string name);

        IEnumerable<Role> GetRoles();

        int AddRole(Role role);

        int EditRole(Role role);

        int RemoveRole(int id);
    }
}

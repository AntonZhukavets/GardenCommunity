using GardenCommunity.DataAccess.Entities;
using System.Collections.Generic;

namespace GardenCommunity.DataAccess.Interfaces
{
    public interface IDBManagerRole
    {
        Role GetRole(int id);

        IEnumerable<Role> GetRoles();

        Role GetRole(string name);

        int AddRole(Role role);

        int EditRole(Role role);

        int RemoveRole(int id);
    }
}

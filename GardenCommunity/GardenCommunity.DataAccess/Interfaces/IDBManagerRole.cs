using GardenCommunity.DataAccess.Entities;

namespace GardenCommunity.DataAccess.Interfaces
{
    public interface IDBManagerRole
    {
        Role GetRole(int id);
        int AddRole(Role role);
        int EditRole(Role role);
        int RemoveRole(int id);
    }
}

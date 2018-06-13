using GardenCommunity.DataAccess.Entities;

namespace GardenCommunity.DataAccess.Interfaces
{
    public interface IDBManagerUser
    {
        User GetUser(int id);
        int AddUser(User user);
        int EditUser(User user);
        int RemoveUser(int id);
    }
}

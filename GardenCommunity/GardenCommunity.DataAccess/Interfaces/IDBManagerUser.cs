using GardenCommunity.DataAccess.Entities;
using System.Collections.Generic;

namespace GardenCommunity.DataAccess.Interfaces
{
    public interface IDBManagerUser
    {
        User GetUser(int id);

        User GetUser(string userName, string password);

        IEnumerable<User> GetUsers();

        int AddUser(User user);

        int EditUser(User user);

        int RemoveUser(int id);
    }
}

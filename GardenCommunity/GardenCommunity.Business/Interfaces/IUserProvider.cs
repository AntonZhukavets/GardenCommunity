using GardenCommunity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardenCommunity.Business.Interfaces
{
    public interface IUserProvider
    {
        User GetUser(string userName, string password);
        int AddUser(User user);
        int EditUser(User user);
        int RemoveUser(int id);
    }
}

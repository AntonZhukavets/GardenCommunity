using GardenCommunity.Business.Interfaces;
using GardenCommunity.Common.Entities;
using GardenCommunity.Common.Mappers;
using GardenCommunity.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardenCommunity.Business.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IDBManagerUser dBManagerUser;
        public UserProvider(IDBManagerUser dBManagerUser)
        {
            this.dBManagerUser = dBManagerUser;
        }
        public int AddUser(User user)
        {
            var User = user ?? throw new ArgumentNullException("user");
            return dBManagerUser.AddUser(Mapper.FromBusinessToDataAccessMap(user));
        }

        public int EditUser(User user)
        {
            var User = user ?? throw new ArgumentNullException("user");
            return dBManagerUser.EditUser(Mapper.FromBusinessToDataAccessMap(user));
        }

        public User GetUser(string userName, string password)
        {
            if(string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName");
            }
            if(string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }
            return Mapper.FromDataAccessToBusinessMap(dBManagerUser.GetUser(userName, password));
        }

        public User GetUser(int id)
        {
            return Mapper.FromDataAccessToBusinessMap(dBManagerUser.GetUser(id));
        }

        public IEnumerable<User> GetUsers()
        {
            var users = new List<User>();
            var dALUsers = dBManagerUser.GetUsers();
            foreach (var user in dALUsers)
            {
                users.Add(Mapper.FromDataAccessToBusinessMap(user));
            }
            return users;
        }

        public int RemoveUser(int id)
        {
            return dBManagerUser.RemoveUser(id);
        }
    }
}

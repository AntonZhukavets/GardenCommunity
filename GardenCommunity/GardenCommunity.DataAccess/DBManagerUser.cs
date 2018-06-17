using GardenCommunity.DataAccess.Entities;
using GardenCommunity.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GardenCommunity.DataAccess
{
    public class DBManagerUser : IDBManagerUser
    {
        public int AddUser(User user)
        {
            var User = user ?? throw new ArgumentNullException("user");
            using (var db = new GardenCommunityContext())
            {
                var someUser = db.Users
                    .FirstOrDefault(x => x.UserName == user.UserName);
                if (someUser == null)
                {
                    var role = db.Roles.First(x => x.Id == user.RoleId);
                    db.Roles.Attach(role);
                    db.Add(user);
                    db.SaveChanges();
                }
                return user.Id;
            }
        }

        public int EditUser(User user)
        {
            var User = user ?? throw new ArgumentNullException("user");
            using (var db = new GardenCommunityContext())
            {
                var updatatableUser = db.Users.First(x => x.Id == user.Id);
                updatatableUser.UserName = user.UserName;
                updatatableUser.Password = user.Password;
                updatatableUser.RoleId = user.RoleId;
                db.SaveChanges();
                return user.Id;
            }
        }

        public User GetUser(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                return db.Users.Include(x => x.Role).First(x => x.Id == id);
            }
        }

        public User GetUser(string userName, string password)
        {
            using (var db = new GardenCommunityContext())
            {
                return db.Users
                    .Include(x=>x.Role)
                    .FirstOrDefault(x => x.UserName == userName && x.Password == password);
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (var db = new GardenCommunityContext())
            {
                return db.Users.Include(x => x.Role).ToList() ?? new List<User>();
            }
        }

        public int RemoveUser(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var user = db.Users.First(x => x.Id == id);
                db.Users.Remove(user);
                db.SaveChanges();
                return user.Id;
            }
        }
    }
}

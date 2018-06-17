using GardenCommunity.DataAccess.Entities;
using GardenCommunity.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GardenCommunity.DataAccess
{
    public class DBManagerRole : IDBManagerRole
    {
        public int AddRole(Role role)
        {
            var Role = role ?? throw new ArgumentNullException("role");
            using (var db = new GardenCommunityContext())
            {
                var someRole = db.Roles.FirstOrDefault(x => x.Name == role.Name);
                if (someRole == null)
                {
                    db.Roles.Add(role);
                    db.SaveChanges();
                    return role.Id;
                }
                return 0;                
            }
        }

        public int EditRole(Role role)
        {
            var Role = role ?? throw new ArgumentNullException("role");
            using (var db = new GardenCommunityContext())
            {
                var updatableRole = db.Roles.First(x => x.Id == role.Id);
                updatableRole.Name = role.Name;
                db.SaveChanges();
                return role.Id;
            }
        }

        public Role GetRole(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                return db.Roles.First(x => x.Id == id);
            }
        }

        public Role GetRole(string name)
        {
            using (var db = new GardenCommunityContext())
            {
                return db.Roles.First(x => x.Name == name);
            }
        }

        public IEnumerable<Role> GetRoles()
        {
            using (var db = new GardenCommunityContext())
            {
                return db.Roles.ToList() ?? new List<Role>();
            }
        }

        public int RemoveRole(int id)
        {
            using (var db = new GardenCommunityContext())
            {
                var role = db.Roles.First(x => x.Id == id);
                db.Roles.Remove(role);
                db.SaveChanges();
                return role.Id;
            }
        }
    }
}

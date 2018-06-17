using GardenCommunity.Business.Interfaces;
using GardenCommunity.Common.Entities;
using GardenCommunity.Common.Mappers;
using GardenCommunity.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace GardenCommunity.Business.Providers
{
    public class RoleProvider : IRoleProvider
    {
        private readonly IDBManagerRole dBManagerRole;
        public RoleProvider(IDBManagerRole dBManagerRole)
        {
            this.dBManagerRole = dBManagerRole;
        }
        public int AddRole(Role role)
        {
            var Role = role ?? throw new ArgumentNullException("role");
            return dBManagerRole.AddRole(Mapper.FromBusinessToDataAccessMap(role));
        }

        public int EditRole(Role role)
        {
            var Role = role ?? throw new ArgumentNullException("role");
            return dBManagerRole.EditRole(Mapper.FromBusinessToDataAccessMap(role));
        }

        public Role GetRole(int id)
        {
            return Mapper.FromDataAccessToBusinessMap(dBManagerRole.GetRole(id));
        }

        public Role GetRole(string name)
        {
            return Mapper.FromDataAccessToBusinessMap(dBManagerRole.GetRole(name));
        }

        public IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>();
            var dALRoles = dBManagerRole.GetRoles();
            foreach (var role in dALRoles)
            {
                roles.Add(Mapper.FromDataAccessToBusinessMap(role));
            }
            return roles;
        }

        public int RemoveRole(int id)
        {
            return dBManagerRole.RemoveRole(id);
        }
    }
}

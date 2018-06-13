using System;
using System.Collections.Generic;
using System.Text;

namespace GardenCommunity.DataAccess.Entities
{
    /// <summary>
    /// Class that describes table Roles in database. Will use in Entity Framework code first
    /// </summary>
    public class Role
    {
        public Role()
        {
            this.Users = new List<User>();
        }
        /// <summary>
        /// Gets or sets Id column in table Roles
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name column in table Roles
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets navigation property 
        /// </summary>
        public ICollection<User> Users { get; set; }
    }
}

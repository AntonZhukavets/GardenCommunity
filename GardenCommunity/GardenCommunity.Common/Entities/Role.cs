using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GardenCommunity.Common.Entities
{
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Role name is rquired")]
        [MaxLength(length: 50, ErrorMessage = "Max lenght is 50 letters")]
        [Display(Name = "Role name")]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        
    }
}

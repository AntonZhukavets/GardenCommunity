using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GardenCommunity.Common.Entities
{
    public class User
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "User name is rquired")]
        [MaxLength(length: 50, ErrorMessage = "Max lenght is 50 letters")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is rquired")] 
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int? RoleId { get; set; }

    }
}

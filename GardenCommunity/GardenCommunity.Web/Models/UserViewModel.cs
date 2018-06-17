using GardenCommunity.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace GardenCommunity.Web.Models
{
    public class UserViewModel : User
    {
        public UserViewModel() : base() { }   
        [Display(Name ="Confirm password")]
        [Required(ErrorMessage = "Passwords confirmation is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}

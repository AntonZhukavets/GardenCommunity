using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GardenCommunity.Web.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Last name is required")]
        [MaxLength(length:100, ErrorMessage = "Max lenght is 100 letters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(length: 100, ErrorMessage = "Max lenght is 100 letters")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [MaxLength(length: 150, ErrorMessage = "Max lenght is 150 letters")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage ="Phone format is incorrect")]
        [MaxLength(length: 20, ErrorMessage = "Max lenght is 100 letters")]
        public string Phone { get; set; }
        public string AdditionalInfo { get; set; }
        public bool IsActiveMember { get; set; }
        public ICollection<Area> Areas { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
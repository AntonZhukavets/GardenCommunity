using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GardenCommunity.Web.Models
{
    public class Area
    {
        public int Id { get; set; }        
        [Required(ErrorMessage ="Square is required")]
        public int Square { get; set; }

        [Display(Name = "Is private")]
        public bool IsPrivate { get; set; }

        [Display(Name = "Has electricity")]
        public bool HasElectricity { get; set; }
        public Area ParentArea { get; set; }

        [Display(Name = "Parent area id")]
        public int? ParentAreaId { get; set; }        
        public ICollection<Member> Members { get; set; }
        [Display(Name = "Owner")]
        public int MemberId { get; set; }
        public int CurrentOwnerId { get; set; }
    }
}
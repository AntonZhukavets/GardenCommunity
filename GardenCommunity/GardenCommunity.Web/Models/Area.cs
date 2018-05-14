using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GardenCommunity.Web.Models
{
    public class Area
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Square is required")]
        public int Square { get; set; }
        public bool IsPrivate { get; set; }
        public bool HasElectricity { get; set; }
        public Area ParentArea { get; set; }
        public int? ParentAreaId { get; set; }
        public ICollection<Member> Member { get; set; }        
    }
}
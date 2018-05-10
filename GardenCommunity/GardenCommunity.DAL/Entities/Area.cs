using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GardenCommunity.DAL.Entities
{
    public class Area
    {
        public int Id { get; set; }
        public int Square { get; set; }
        public bool IsPrivate { get; set; }
        public bool HasElectricity { get; set; }
        public Area AdditionalArea { get; set; }
        public int? AdditionalAreaId { get; set; }
        public Member Member { get; set; }        
        public int MemberId { get; set; }
    }
}

using System.Collections.Generic;

namespace GardenCommunity.Business.DTO
{
    public class Area
    {
        public int Id { get; set; }
        public int Square { get; set; }
        public bool IsPrivate { get; set; }
        public bool HasElectricity { get; set; }
        public Area ParentArea { get; set; }
        public int? ParentAreaId { get; set; }
        public ICollection<Member> Members { get; set; }
        public int MemberId { get; set; }
        public bool IsFree { get; set; }
        public Area()
        {
            Members = new List<Member>();
        }
    }
}

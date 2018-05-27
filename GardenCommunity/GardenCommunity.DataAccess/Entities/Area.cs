using System.Collections.Generic;

namespace GardenCommunity.DataAccess.Entities
{
    public class Area
    {
        public int Id { get; set; }
        public int Square { get; set; }
        public bool IsPrivate { get; set; }
        public bool HasElectricity { get; set; }
        public Area ParentArea { get; set; }
        public int? ParentAreaId { get; set; }
        public ICollection<MembersAreas> MembersAreas { get; set; }
        public Area()
        {
            MembersAreas = new List<MembersAreas>();
        }
    }
}

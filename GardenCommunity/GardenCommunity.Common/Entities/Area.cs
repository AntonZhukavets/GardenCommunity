using System;
using System.Collections.Generic;
using System.Text;

namespace GardenCommunity.Common.Entities
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
        public DateTime OwnedFrom { get; set; }
        public DateTime OwnedTo { get; set; }
        public Area()
        {
            Members = new List<Member>();
        }
    }
}

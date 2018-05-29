using System;
using System.Collections.Generic;
using System.Text;
using DAL = GardenCommunity.DataAccess.Entities;

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

        public static explicit operator DAL.Area(Area input){
            return new DAL.Area {
      Id = input.Id
};
    }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GardenCommunity.DataAccess.Entities
{
    public class MembersAreas
    {
        public int MemberId { get; set; }
        public int AreaId { get; set; }
        public int Id { get; set; }
        public Area Area { get; set; }
        public Member Member { get; set; }
        public DateTime OwnedFrom { get; set; }
        public DateTime? OwnedTo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenCommunity.DAL.Entities
{
    public class MembersAreas
    {
        public int MemberId { get; set; }
        public int AreaId { get; set; }
        public int Id { get; set; }
        public Area Area { get; set; }
        public Member Member { get; set; }
    }
}

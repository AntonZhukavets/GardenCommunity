using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Member Member { get; set; }
        public int MemberId { get; set; }
    }
}

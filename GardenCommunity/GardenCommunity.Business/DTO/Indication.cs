using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenCommunity.Business.DTO
{
    public class Indication
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double LastIndication { get; set; }
        public double CurrentIndication { get; set; }
        public double LoosesPercent { get; set; }
        public Payment Payment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

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

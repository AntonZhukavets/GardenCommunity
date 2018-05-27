using System;
using System.Collections.Generic;
using System.Text;

namespace GardenCommunity.Common.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime DateOfPayment { get; set; }
        public double PaidFor { get; set; }
        public double ToPay { get; set; }
        public Rate Rate { get; set; }
        public int RateId { get; set; }
        public Indication Indication { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
    }
}

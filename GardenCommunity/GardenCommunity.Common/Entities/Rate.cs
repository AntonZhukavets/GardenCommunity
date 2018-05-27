using System;
using System.Collections.Generic;


namespace GardenCommunity.Common.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public string RateName { get; set; }
        public double RateValue { get; set; }
        public double BankCollectionPercent { get; set; }
        public double FinePercent { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}

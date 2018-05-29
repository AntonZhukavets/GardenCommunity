using System;
using System.Collections.Generic;

namespace GardenCommunity.DataAccess.Entities
{
    /// <summary>
    /// Class that describes table Rates in database. Will use in Entity Framework code first
    /// </summary>
    public class Rate
    {
        /// <summary>
        /// Gets or sets Id column in table Rates
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets RateName column in table Rates
        /// </summary>
        public string RateName { get; set; }

        /// <summary>
        /// Gets or sets RateValue column in table Rates
        /// </summary>
        public double RateValue { get; set; }

        /// <summary>
        /// Gets or sets BankCollectionPercent column in table Rates
        /// </summary>
        public double BankCollectionPercent { get; set; }

        /// <summary>
        /// Gets or sets FinePercent column in table Rates
        /// </summary>
        public double FinePercent { get; set; }

        /// <summary>
        /// Gets or sets Date column in table Rates
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets navigation property in table Rates
        /// </summary>
        public ICollection<Payment> Payments { get; set; }
    }
}

using System;

namespace GardenCommunity.DataAccess.Entities
{
    /// <summary>
    /// Class that describes table Payments in database. Will use in Entity Framework code first
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Gets or sets Id column in table Payments
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets DateOfPayment column in table Payments
        /// </summary>
        public DateTime DateOfPayment { get; set; }

        /// <summary>
        /// Gets or sets PaidFor column in table Payments
        /// </summary>
        public double PaidFor { get; set; }

        /// <summary>
        /// Gets or sets ToPay column in table Payments
        /// </summary>
        public double ToPay { get; set; }

        /// <summary>
        /// Gets or sets navigation property in table Payments
        /// </summary>
        public Rate Rate { get; set; }

        /// <summary>
        /// Gets or sets RateId column in table Payments
        /// </summary>
        public int RateId { get; set; }

        /// <summary>
        /// Gets or sets navigation property column in table Payments
        /// </summary>
        public Indication Indication { get; set; }

        /// <summary>
        /// Gets or sets navigation property column in table Payments
        /// </summary>
        public Member Member { get; set; }

        /// <summary>
        /// Gets or sets MemberId column in table Payments
        /// </summary>
        public int MemberId { get; set; }
    }
}

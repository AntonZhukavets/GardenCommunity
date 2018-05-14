using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GardenCommunity.Web.Models
{
    public class Rate
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is rquired")]
        [MaxLength(length: 50, ErrorMessage = "Max lenght is 50 letters")]
        public string RateName { get; set; }
        [Required(ErrorMessage = "Value is rquired")]
        public double RateValue { get; set; }
        [Required(ErrorMessage = "Bank collection is rquired")]
        public double BankCollectionPercent { get; set; }
        [Required(ErrorMessage = "Fine percent is rquired")]
        public double FinePercent { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
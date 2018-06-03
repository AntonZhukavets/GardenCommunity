using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GardenCommunity.Common.Entities
{
    public class Rate
    {
        public Rate()
        {
            this.Payments = new List<Payment>();    
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is rquired")]
        [MaxLength(length: 50, ErrorMessage = "Max lenght is 50 letters")]
        [Display(Name = "Rate name")]
        public string RateName { get; set; }

        [Required(ErrorMessage = "Value is rquired")]
        [Display(Name = "Rate value")]
        public double RateValue { get; set; }

        [Required(ErrorMessage = "Bank collection is rquired")]
        [Display(Name = "Bank collection %")]
        public double BankCollectionPercent { get; set; }

        [Required(ErrorMessage = "Fine percent is rquired")]
        [Display(Name = "Fine %")]
        public double FinePercent { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Display(Name = "Rate date")]
        public DateTime Date { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}

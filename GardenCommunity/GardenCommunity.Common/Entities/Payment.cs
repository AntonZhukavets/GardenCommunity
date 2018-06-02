using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GardenCommunity.Common.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Date of payment")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DateOfPayment { get; set; }

        [Required(ErrorMessage = "Paid for is required")]
        [Display(Name = "Paid for")]
        public double PaidFor { get; set; }

        [Required(ErrorMessage = "Paid to is required")]
        [Display(Name = "Paid to")]
        public double ToPay { get; set; }

        public Rate Rate { get; set; }

        [Required(ErrorMessage = "Rate is required")]
        [Display(Name = "Rait")]
        public int RateId { get; set; }
        public Indication Indication { get; set; }
        public Member Member { get; set; }

        [Required(ErrorMessage = "Member is required")]
        [Display(Name = "Member")]
        public int MemberId { get; set; }
    }
}

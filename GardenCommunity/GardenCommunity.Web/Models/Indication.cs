using System.ComponentModel.DataAnnotations;

namespace GardenCommunity.Web.Models
{
    public class Indication
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Month is required")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        [Display(Name = "Last indication")]
        [Required(ErrorMessage = "Last indications is required")]
        public double LastIndication { get; set; }

        [Display(Name = "Current indication")]
        [Required(ErrorMessage = "Current indications is required")]
        public double CurrentIndication { get; set; }

        [Display(Name = "Looses %")]
        [Required(ErrorMessage = "Looses percent is required")]
        public double LoosesPercent { get; set; }

        public Payment Payment { get; set; }
    }
}
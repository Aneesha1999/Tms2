using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tms2.Models
{
    public class vehicleinformation
    {
        [Key]
        [Required(ErrorMessage = "vehicle number should be unique")]
        public int vehiclenumber { get; set; }
        [Required(ErrorMessage = "no of passengers can occupy the seat")]
        public int capacity { get; set; }
        [Required(ErrorMessage = "no of seats available")]
        [Display(Name ="Available Seats")]
        public int Availableseats { get; set; }
        [Required(ErrorMessage = "vehicle available to the location")]
        public string operable { get; set; }

    }
}

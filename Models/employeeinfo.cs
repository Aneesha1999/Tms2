using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tms2.Models
{
    public class employeeinfo
    {
        [Key]

        public int employeeid { get; set; }
        [Required(ErrorMessage = "enter your name")]
        public string name { get; set; }
        [Required(ErrorMessage = "enter your age")]
        public int age { get; set; }
        [Required(ErrorMessage = "enter your location")]
        public string location { get; set; }

        [Required(ErrorMessage = "enter your phone no")]
        public string phoneno { get; set; }
        [Required(ErrorMessage = "enter your vehicleID")]
        public int vehicleID { get; set; }




    }
}

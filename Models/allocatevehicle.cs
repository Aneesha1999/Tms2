using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tms2.Models
{
    public class allocatevehicle

    {
        [Key]
        [Required(ErrorMessage = "enter your Employeename")]
        public string Employeename { get; set; }
        [Required(ErrorMessage = "enter your Employeelocation")]
        public string Employeelocation { get; set; }
        [Required(ErrorMessage = "enter your Emp phone no")]
        public string Empphoneno { get; set; }
        [Required(ErrorMessage = "enter your Employeeage")]
        public int Employeeage { get; set; }


        [Required(ErrorMessage = "allocate vehicle to employee")]
        public string vehicleallocationtoEmployee { get; set; }
    }
}

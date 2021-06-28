using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tms2.Models
{
    public class userregistration
    {
        [Key]
        [Required(ErrorMessage = "enter your first name")]
        [Display(Name = "User_firstname")]



        public string User_firstname { get; set; }
        [Required(ErrorMessage = "enter your last name")]


        [Display(Name = "User_Last name")]
        public string User_lastname { get; set; }



        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression(@"^[a-zA-Z0-9\s]{8,15}$", ErrorMessage = "Please enter more than 8 character and special characters are not allowed")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression(@"^[a-zA-Z0-9\s]{8,15}$", ErrorMessage = "Please enter more than 8 character and special characters are not allowed")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password not matched")]
        public String CPassword { get; set; }

    }
}

    

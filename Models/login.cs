using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tms2.Models
{
    public class login
    {
        [Key]
        [Required(ErrorMessage = "enter your user name")]
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression(@"^[a-zA-Z0-9\s]{8,15}$", ErrorMessage = "Please enter more than 8 character and special characters are not allowed")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}


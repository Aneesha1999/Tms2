using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tms2.Models
{
    public class routeinformation
    {
        [Key]
        [Required(ErrorMessage = "Rootnumber should be unique")]
        public int rootnumber { get; set; }
        public int vehiclenumber { get; set; }
        public string stops { get; set; }

    }
}

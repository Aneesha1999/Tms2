using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tms2.Models
{
    public class modify
    {
        [Key]
        public string employee { get; set; }
        public string vehicle { get; set; }
        [Required(ErrorMessage = "enter the correct route")]
        public string routeinfo { get; set; }

    }
}

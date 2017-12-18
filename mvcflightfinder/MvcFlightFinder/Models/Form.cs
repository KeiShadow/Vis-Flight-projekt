using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcFlightFinder.Models
{
    public class Form
    {

        [Required]
        [Display(Name = "Odkud letím?")]
        public string srchFrom { get; set; }
        [Display(Name = "Kam letím?")]
        [Required]
        public string srchTo { get; set; }
        [Required]
        [Display(Name = "Kdy mi to letí?")]
        public string dateFrom { get; set; }
    }
}
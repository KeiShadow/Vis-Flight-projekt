using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBHandler.DataMapper
{
    public class FavoriteFligths
    {
        public int Idf { get; set; }
        public int IdUser { get; set; }
        [Required]
        [Display(Name = "Odkud letím?")]
        public string FlyFrom { get; set; }
        [Required]
        [Display(Name = "Kam letím?")]
        public string FlyTo { get; set; }
        [Required]
        [Display(Name = "Od kdy letím?")]
        public string Datefrom { get; set; }
        [Required]
        [Display(Name = "Cena?")]
        public int Price { get; set; }

    }
}
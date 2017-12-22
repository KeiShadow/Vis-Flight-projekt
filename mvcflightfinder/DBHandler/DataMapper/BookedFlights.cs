using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBHandler.DataMapper
{
    public class BookedFlights
    {
        public int Idb { get; set; }
        [Required]
        [Display(Name = "Odkud letím?")]
        public string FlyFrom { get; set; }
        [Required]
        [Display(Name = "Kam letím?")]
        public string FlyTo { get; set; }
        [Required]
        [Display(Name = "Kdy letím?")]
        public string Datefrom { get; set; }
        [Required]
        [Display(Name = "Počet lidí")]
        public int Peoples { get; set; }
        public int Price { get; set; }
        public int Users_id { get; set; }
        [Required]
        [Display(Name = "Datum rezervace?")]
        public string Dateofres { get; set; }
        [Required]
        [Display(Name = "Jméno?")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Příjjemní?")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Pohlaví?")]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Gender { get; set; }
    }
}
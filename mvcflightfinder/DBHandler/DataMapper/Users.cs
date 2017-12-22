using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBHandler.DataMapper
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nick")]
        public string Nick { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "heslo")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Jméno")]
        public string Firstname { get; set; }
        [Required]
        [Display(Name = "Příjmení")]
        public string Lastname { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFlightFinder.DataMapper
{
    public class Users
    {
        public int id { get; set; } 
        public string login { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string permision { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFlightFinder.DataMapper
{
    public class Settings
    {
        public int id { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Users iduser { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFlightFinder.DataMapper
{
    public class BookedFlights
    {
        public int Idb { get; set; }
        public string FlyFrom { get; set; }
        public string FlyTo { get; set; }
        public string Datefrom { get; set; }
        public int Peoples { get; set; }
        public int Price { get; set; }
        public int Users_id { get; set; }
        public string Dateofres { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
    }
}
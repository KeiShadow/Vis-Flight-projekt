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
        public DateTime Datefrom { get; set; }
        public int Peoples { get; set; }
        public int Price { get; set; }
        public int Users_id { get; set; }
        public DateTime Dateofres { get; set; }
    }
}
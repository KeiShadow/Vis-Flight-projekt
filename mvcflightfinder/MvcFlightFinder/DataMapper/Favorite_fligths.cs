using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFlightFinder.DataMapper
{
    public class Favorite_fligths
    {
        public int iduser { get; set; }
        public int id { get; set; }
        public string flightFrom { get; set; }
        public string flightTo { get; set; }
        public string dateFrom { get; set; }
        public string price { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFlightFinder.DataMapper
{
    public class FavoriteFligths
    {
        public int Idf { get; set; }
        public int IdUser { get; set; }
        public string FlyFrom { get; set; }
        public string FlyTo { get; set; }
        public string Datefrom { get; set; }
        public int Price { get; set; }

    }
}
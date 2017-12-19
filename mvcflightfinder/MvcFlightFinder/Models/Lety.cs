using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFlightFinder.Models
{
    public class Lety
    {
        public int Id { get; set; }

        public string IdCollapse { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public int Cena { get; set; }

        public string dateFrom { get; set; }

        public string Duration { get; set; }

    }

}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightFroms
{
    public class JsonParser
    {
        public static List<Location> locList = new List<Location>();

        public List<Location> getPlaces()
        {
            using (StreamReader r = new StreamReader(@"D:\GitHub\Vis-Flight-projekt\mvcflightfinder\FlightFroms\Places\places.json"))
            {
                string json = r.ReadToEnd();
                locList = JsonConvert.DeserializeObject<List<Location>>(json);
            }
            return locList;
        }


    }
}

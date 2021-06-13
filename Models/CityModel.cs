using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTravel.Models
{
    public class CityModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string photoURl { get; set; }
        public string[] comments { get; set; }
    }
}

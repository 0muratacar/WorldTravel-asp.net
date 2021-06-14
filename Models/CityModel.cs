using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTravel.Models
{
    public class CityModel
    {
        // Json dosyasındaki şehir bilgilerini tutmak için oluşturuldu.
        public int id { get; set; }
        public string name { get; set; }
        public string photoUrl { get; set; }
        public string[] comments { get; set; }
        public string[] favoriFoods { get; set; }
        public string[] favoriLocations { get; set; }
    }
}

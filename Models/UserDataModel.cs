using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTravel.Models
{
    public class UserDataModel
    {

        // Eklenen kullanıcıların bilgilerinin tutulduğu bölüm
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string eposta { get; set; }
        public string password { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public string posta_kodu { get; set; }
        public string adres { get; set; }
    }
}

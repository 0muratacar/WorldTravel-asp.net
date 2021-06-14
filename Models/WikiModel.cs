using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTravel.Models
{
    public class WikiModel
    {
        public string batchcomplete { get; set; }
        public Query query { get; set; }
    }

    public class Query
    {
        public Dictionary<string, pageval> pages { get; set; }

    }

    public class pageval
    {
        // Gelen linkin verilerini ayrıştırırken kullandığımız değişkenler bu modelde tutuluyor.
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
        public string extract { get; set; }

    }

}


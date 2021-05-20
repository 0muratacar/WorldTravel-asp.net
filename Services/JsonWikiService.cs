using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WorldTravel.Models;

namespace WorldTravel.Services
{
    public class JsonWikiService
    {
        public WikiModel GetWikiModel (string term)
        {
            // Aramasını istediğimiz term değişkenini alıp url çevirip url adlı stringe atıyoruz..
            string url = string.Concat("https://tr.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&redirects=1&titles=",term);

            // Bu url İ indirip json adlı stringe atıyoruz.
            string json = new WebClient().DownloadString(url);

            // İndirilen json metnini wikiModelimize çeviriyoruz. Seri hale getiriyoruz. Ve bunu wikidata adlı değişkende tutuyoruz.
            WikiModel wikidata = JsonSerializer.Deserialize<WikiModel>(json);

            return wikidata;

            /*
             * return JsonSerializer.Deserialize<WikiModel>(json); de diyebilirdik 22-24. satırları silip.
             * 
            */
        }
    }
}

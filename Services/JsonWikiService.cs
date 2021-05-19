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
        public string GetWikiModel (string term)
        {
            string url = string.Concat("https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&redirects=1&titles=",term);

            string json = new WebClient().DownloadString(url);

            WikiModel wikidata = JsonSerializer.Deserialize<WikiModel>(json);

            return url;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldTravel.Services;
using WorldTravel.Models;

namespace WorldTravel.Pages.navbarPages.tasks
{
    public class week10Model : PageModel
    {
        public JsonWikiService JsonWikiService;

        private readonly ILogger<week10Model> _logger;

        public week10Model(ILogger<week10Model> logger, JsonWikiService jsonwikiservice)
        {
            _logger = logger;
            JsonWikiService = jsonwikiservice;
        }


        public WikiModel wikidata;

        [BindProperty]
        public string Term { get; set; }

        [BindProperty]
        public string Extract { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            Console.WriteLine(Term);
            wikidata = JsonWikiService.GetWikiModel(Term);

            Extract = ExtractData(wikidata);
        }

        public string ExtractData(WikiModel wikidata)
        {

            

                // Pagesin ilk elemanýnýn indisini firstkey adlý deðiþkene attýk.
                string firstkey = wikidata.query.pages.First().Key;
                // Data adlý deðiþkene pagesin ilk elemanýndaki extract içeriðini gönderdik.
                string data = wikidata.query.pages[firstkey].extract;

                return data;

        }
    }
}

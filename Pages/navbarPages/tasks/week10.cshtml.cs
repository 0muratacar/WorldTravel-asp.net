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
        private readonly ILogger<week10Model> _logger;

        public week10Model(ILogger<week10Model> logger, JsonWikiService jsonservice)
        {
            _logger = logger;
            JsonService = jsonservice;
        }

        public JsonWikiService JsonService;

        [BindProperty]
        public string Term { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Console.WriteLine(Term);
            string test = JsonService.GetWikiModel(Term);
        }
    }
}

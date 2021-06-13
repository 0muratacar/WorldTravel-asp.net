using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldTravel.Services;
using WorldTravel.Models;
using Microsoft.Extensions.Logging;

namespace WorldTravel.Pages.navbarPages
{
    public class ShowCityModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Status { get; set; }

        private readonly ILogger<ShowCityModel> _logger;

        public JsonCityService JsonCityService;

        public IEnumerable<CityModel> Cities;

        public ShowCityModel(ILogger<ShowCityModel> logger, JsonCityService jsoncityservice)
        {
            _logger = logger;
            JsonCityService = jsoncityservice;
        }
        public void OnGet()
        {
            Cities = JsonCityService.GetCity();

        }
    }
}



using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldTravel.Models;
using WorldTravel.Services;

namespace WorldTravel.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public JsonCityService JsonCityService;

        public CityController(JsonCityService jsoncityservice)
        {
            JsonCityService = jsoncityservice;
        }

        [HttpGet]
        public IEnumerable<CityModel> Get(string name)
        {
            if (name != null)
            {
                List<CityModel> list = new List<CityModel>();
                list.Add(JsonCityService.GetCityByName(name));
                IEnumerable<CityModel> en = list;
                return en;
            }
            else
            {
                return JsonCityService.GetCity();
            }
        }
    }
}

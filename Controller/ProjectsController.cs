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
    public class ProjectsController : ControllerBase
    {
        public JsonProjectService JsonProjectService;

        public ProjectsController(JsonProjectService jsonprojectservice)
        {
            JsonProjectService = jsonprojectservice;
        }
        
        [HttpGet]
        public IEnumerable<ProjectModel> Get(int id)
        {
            if(id != 0)
            {
                List<ProjectModel> list = new List<ProjectModel>();
                list.Add(JsonProjectService.GetProjectById(id));
                IEnumerable<ProjectModel> en = list;
                return en;
            }
            else
            {
                return JsonProjectService.GetProjects();
            }
        }
    }
}

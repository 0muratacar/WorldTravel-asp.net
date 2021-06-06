using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldTravel.Services;
using WorldTravel.Models;
using Microsoft.Extensions.Logging;

namespace WorldTravel.Pages.navbarPages.tasks
{
    public class week11Model : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string Status { get; set; }

        private readonly ILogger<week11Model> _logger;

        public JsonProjectService JsonProjectService;

        public IEnumerable<ProjectModel> Projects;

        public week11Model(ILogger<week11Model> logger, JsonProjectService jsonprojectservice)
        {
            _logger = logger;
            JsonProjectService = jsonprojectservice;
        }

        public void OnGet()
        {
            Projects = JsonProjectService.GetProjects();
        }
    }
}

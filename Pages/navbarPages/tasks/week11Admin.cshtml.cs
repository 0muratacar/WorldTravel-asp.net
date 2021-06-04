using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldTravel.Models;
using WorldTravel.Services;

namespace WorldTravel.Pages.navbarPages.tasks
{
    public class week11AdminModel : PageModel
    {

        public JsonProjectService JsonProjectService;

        public week11AdminModel(JsonProjectService jsonprojectservice)
        {
            JsonProjectService = jsonprojectservice;
        }

        [BindProperty]
        public ProjectModel Proje { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

            JsonProjectService.AddProject(Proje);
            return RedirectToPage("/NavbarPages/tasks/week11", new { Status = true });

        }
    }
}

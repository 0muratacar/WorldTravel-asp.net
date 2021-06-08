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

        [BindProperty]
        public string MemberList { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPostAddProjectForm()
        {
            Proje.members = stringtolist(MemberList);
            if (Proje.id == 0)
            {
                JsonProjectService.AddProject(Proje);
                return RedirectToPage("/NavbarPages/tasks/week11", new { Status = "AddSuccess" });

            }
            else
            {
                JsonProjectService.UpdateProject(Proje);
                return RedirectToPage("/NavbarPages/tasks/week11", new { Status = "UpdateSuccess" });

            }

        }

        public void OnPostSearchProjectForm()
        {
            Proje = JsonProjectService.GetProjectById(Proje.id);
            if(Proje != null)
            {
                MemberList = listtostring(Proje.members);
            }
        }

        public string[] stringtolist(string MemberList) {
            if( MemberList != null)
            {
                string[] lines = MemberList.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                return lines;
            }
            return Array.Empty<string>();
        }
        public string listtostring(string[] MemberList) {
            return string.Join(Environment.NewLine, MemberList);
        }

        public IActionResult OnPostDeleteProjectByID()
        {
            if(Proje.id != 0)
            {
                JsonProjectService.DeleteProject(Proje.id);
                return RedirectToPage("/NavbarPages/tasks/week11", new { Status = "DeleteError" });

            }
            else
            {
                return RedirectToPage("/NavbarPages/tasks/week11", new { Status = true });
            }


        }


    }
}

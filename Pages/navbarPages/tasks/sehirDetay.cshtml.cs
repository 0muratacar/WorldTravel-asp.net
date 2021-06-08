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
    public class sehirDetayModel : PageModel
    {
        public JsonCityService JsonCityService;
        public sehirDetayModel(JsonCityService jsoncityservice)
        {
            JsonCityService = jsoncityservice;
        }

        [BindProperty]
        public CityModel City { get; set; }

        [BindProperty]
        public string CommentList { get; set; }
        public void OnGet()
        {
        }

        public void OnPostSearchCityForm()
        {
            // Jsonda olmayan bir isim gelince patlýyor. Yoksa Çalýþýyor.
            City = JsonCityService.GetCityByName(City.name);
            if (City.name != null)
            {
                CommentList = listtostring(City.comments);
            }
        }


        public IActionResult OnPostAddCityForm()
        {
            City.comments = stringtolist(CommentList);
            if (City.id == 0)
            {
                JsonCityService.AddCity(City);
                return RedirectToPage("/NavbarPages/tasks/week11", new { Status = "AddSuccess" });

            }
            else
            {
                JsonCityService.UpdateCity(City);
                return RedirectToPage("/NavbarPages/tasks/week11", new { Status = "UpdateSuccess" });

            }

        }

        public string[] stringtolist(string CommentList)
        {
            if (CommentList != null)
            {
                string[] lines = CommentList.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                return lines;
            }
            return Array.Empty<string>();
        }
        public string listtostring(string[] CommentList)
        {
            return string.Join(Environment.NewLine, CommentList);
        }
    }
}


//namespace WorldTravel.Pages.navbarPages.tasks
//{
//    public class week11AdModel : PageModel
//    {




//        public IActionResult OnPostDeleteProjectByID()
//        {
//            if (Proje.id != 0)
//            {
//                JsonProjectService.DeleteProject(Proje.id);
//                return RedirectToPage("/NavbarPages/tasks/week11", new { Status = "DeleteError" });

//            }
//            else
//            {
//                return RedirectToPage("/NavbarPages/tasks/week11", new { Status = true });
//            }


//        }


//    }
//}

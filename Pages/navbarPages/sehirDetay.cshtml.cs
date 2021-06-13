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

        [BindProperty(SupportsGet = true)]
        public string Status { get; set; }

        [BindProperty]
        public CityModel City { get; set; }

        [BindProperty]
        public string CommentList { get; set; }
        [BindProperty]
        public string FoodList { get; set; }
        [BindProperty]
        public string LocationList { get; set; }
        [BindProperty]
        public string PhotoUrl { get; set; }

        public void OnGet()
        {
        }
        
        public void OnPostSearchCityForm()
        {
             var d= JsonCityService.GetCity();
            // Jsonda olmayan bir isim gelince patl�yor. Yoksa �al���yor.
            City = JsonCityService.GetCityByName(City.name);
            /*
             * for d�ng�s� ile City.name =? sehirveri.json i�indeki name isimleriyle
             * e�le�irse statu 1
             * else 0;
             *
             */
            
            //foreach (string names in d)
            //{
                
            //};
            if (City.name != null)
            {
                CommentList = listtostring(City.comments);
                FoodList = listtostring(City.favoriFoods);
                LocationList = listtostring(City.favoriLocations);
            }
            else
            {
                Console.WriteLine("�ehir bulunamad�");
                //return RedirectToPage("/NavbarPages/sehirDetay", new { Status = "no" });
            }
        }


        public IActionResult OnPostAddCityForm()
        {
            City.comments = stringtolist(CommentList);
            City.favoriLocations = stringtolist(LocationList);
            City.favoriFoods = stringtolist(FoodList);
            if (City.id == 0)
            {
                JsonCityService.AddCity(City);
                return RedirectToPage("/NavbarPages/ShowCity", new { Status = "AddSuccess" });

            }
            else
            {
                JsonCityService.UpdateCity(City);
                return RedirectToPage("/NavbarPages/ShowCity", new { Status = "UpdateSuccess" });

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

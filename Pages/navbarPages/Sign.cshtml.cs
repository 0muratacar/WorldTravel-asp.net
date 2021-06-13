using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldTravel.Models;

namespace WorldTravel.Pages.navbarPages
{
    public class SignModel : PageModel
    {


        [BindProperty]
        public UserDataModel UserData { get; set; }
        public void OnGet()
        {
            Console.WriteLine("selam");
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Index" ,new {Name=UserData.Ad, Surname=UserData.Soyad });
        }
    }
}

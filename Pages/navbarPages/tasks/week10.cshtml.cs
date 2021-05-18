using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorldTravel.Pages.navbarPages.tasks
{
    public class week10Model : PageModel
    {

        [BindProperty]
        public string Term { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Console.WriteLine(Term);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using city.data.Abstract;
using city.entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldTravel.Models;

namespace WorldTravel.Pages.navbarPages
{

    public class SignInModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Status { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        IUser _user;


        public SignInModel(IUser user)
        {
            _user = user;
        }



        [BindProperty]
        public UserDataModel UserData { get; set; }
        public void OnGet()
        {


        }


        public IActionResult OnPost()
        {
            string email = UserData.eposta;
            string password = UserData.password;

            User user = new User();
            user = _user.findUser(email, password);

            if(user != null)
            {
                return RedirectToPage("/Index", new { Name = user.name });
            }
            return RedirectToPage("/navbarPages/SignIn", new { Status = "Error"});



        }
    }
}


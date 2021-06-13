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
    public class SignModel : PageModel
    {
         IUser _user;


        public SignModel(IUser user){
            _user=user;
        }



        [BindProperty]
        public UserDataModel UserData { get; set; }
        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {
        
            User new_user=new User(){
               name=UserData.name,
               surname=UserData.surname,
               eposta=UserData.eposta,
               il=UserData.il,
               ilce=UserData.ilce,
               posta_kodu=UserData.posta_kodu,
               adres=UserData.adres

            };
            
            _user.addUser(new_user);
            //return redirect to action();
            return RedirectToPage("/Index" ,new {Name=UserData.name, Surname=UserData.surname });
        }
    }
}

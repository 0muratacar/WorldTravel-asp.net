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

    public class SignUpModel : PageModel


    {
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Surname { get; set; }


        // User repositorye baðlamak için bir nesne oluþturuldu.
        IUser _user;

        // Constructer her çalýþtýðýnda nesne oluþturuluyor.
        public SignUpModel(IUser user){
            _user=user;
        }



        [BindProperty]
        public UserDataModel UserData { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "";
            }

        }

        // Girilen deðerlere alýnýp new_user adlý User nesneye atanýp, Bu veri veritabanýna IUser nesnesi ile kaydediliyor.
        public IActionResult OnPost()
        {
        
            User new_user=new User(){
               name=UserData.name,
               surname=UserData.surname,
               eposta = UserData.eposta,
               password = UserData.password,
               il = UserData.il,
               ilce=UserData.ilce,
               posta_kodu=UserData.posta_kodu,
               adres=UserData.adres

            };
            
            _user.addUser(new_user);
            //return redirect to action();
            //return RedirectToPage("/Index" ,new {Name=UserData.name, Surname=UserData.surname });
            return RedirectToPage("/navbarPages/SignIn", new { Name = UserData.name, Surname = UserData.surname });
        }
    }
}


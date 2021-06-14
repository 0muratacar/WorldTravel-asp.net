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

        // Status ve Name deðiþkenleri baþarýlý iþlemlerin sonucunda redirect yapýsý ile mesajý dönderiyor.
        [BindProperty(SupportsGet = true)]
        public string Status { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        // User repositorye baðlamak için bir nesne oluþturuldu.
        IUser _user;

        // Constructer her çalýþtýðýnda nesne oluþturuluyor.
        public SignInModel(IUser user)
        {
            _user = user;
        }



        [BindProperty]
        public UserDataModel UserData { get; set; }

        public void OnGet()
        {

        }

        // Giriþ yapýlan e posta ve þifre bilgileri veritabanýnda eþleþiyorsa baþarýlý bir þekilde indexe yönlendirilir
        // Aksi halde hata mesajý verilerek ayný sayfada kalýr.
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


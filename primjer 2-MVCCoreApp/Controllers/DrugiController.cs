using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace MVCCoreApp.Controllers
{
    public class DrugiController : Controller
    {
        //public ActionResult Index()
        //{
        //    return Ok("Sve OK, pozdrav iz drugog");
        //}

        public string Student(string ime, int godina)
        {
            // return $"Student imena:{ime} je na {godina}. godini faksa";
            // $ je znak za ekstrapoliranje niza (formatiranje niza)
            // poziv ove f-je iz URL: 
            // http://localhost:64597/Drugi/student?ime=Matija&godina=3

            // s ovim primjerom bi mogao injektirati nešto u stranicu. trebao bi koristiti Escape-anje
            // kao nekakva mjera predostrožnosti
            // treba mi using System.Text.Encodings.Web;
            return HtmlEncoder.Default.Encode($"Student imena:{ime} je na {godina}. godini faksa");
        }

        // vraćamo nekakvu našu stranicu, u našem primjeru View
        // u View dodamo folder Drugi
        // automatska veza je takva da traži folder sa svojim imenom

        // otvaramo sa http://localhost:64597/Drugi/stranica
        public ActionResult Stranica()
        {
            return View();
        }

    }
}

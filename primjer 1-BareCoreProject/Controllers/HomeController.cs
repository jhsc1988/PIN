using Microsoft.AspNetCore.Mvc;

namespace BareCoreProject.Controllers
{
    public class HomeController : Controller
    {
        // ovo mi znači kada korisnik napravi nekakav get zahtjev, on mi otvori ovu stranicu
        // i on će mi vratit donji tekst

        [HttpGet("/")]  // "/" ovo je naš url (u ovom slučaju nekakav root URL) -> tu smo direktno vratili return Ok("");
                        // svaki url je jedna dodirna točka (endpoint) naše aplikacije
        public IActionResult Index()
        {
            // Ok je metoda koja generira http 200 - status uspješno sam odgovorio na zahtjev
            // i vrati nekakav tekst
            // inače se vraća error 404
            
            // kontroler moramo pozvati iz Startup.cs

            return Ok("Pozdrav iz kontrolera");
            // return View(); // ovo zakomentiramo
        }

        // endpoint stranice Druga
        [HttpGet("/Druga")] 
        public IActionResult Druga()
        {
            return View();  // prije toga smo kreirali novi View folder -> pa Home folder - i u njeg Druga.cshtml
                            // unutar Home foldera jer pripada ovom našem kontroleru
                            // zove se druga jer pripada ovoj našoj metodi
                            // znači, tu će pročitati sadržaj tog file-a i vratit će ga kao rezultat
        }
    }
}

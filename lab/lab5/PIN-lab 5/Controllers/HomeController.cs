using Microsoft.AspNetCore.Mvc;

namespace PIN_lab_5.Controllers
{

    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Vjezba4/")]
        public IActionResult Vjezba4()
        {
            ViewBag.Text = "Pozdrav iz kontrolera!";
            ViewBag.Title = "Moja stranica";
            return View();
        }
    }
}

using ASPNETCoreModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreModel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["poruka"] = "pozdrav iz kontrolera"; // strongly typed - ovo je objekt pa može biti bilo koji podataka

            ViewBag.Broj = 13;  // dinamičko svojstvo - dobijem eleganciju pisanja
                                // ViewBag je wrapper oko viewdata, kreira dinamičko svojstvo Broj, to ću spremiti u ViewData
                                // tamo će biti podaci , ali će on zapamtit da je to integer

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

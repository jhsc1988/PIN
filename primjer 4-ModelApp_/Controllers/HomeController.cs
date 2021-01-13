using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using primjer_4_ModelApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace primjer_4_ModelApp.Controllers
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
            ViewData["pozdrav"] = "Pozdrav svim PINovcima!";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["pozdrav"] = "Pozdrav svim PINovcima!";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

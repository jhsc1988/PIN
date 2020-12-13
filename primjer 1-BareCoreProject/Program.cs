using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ovo je nekakav bazni program koji pokreæe naš interni web server
// (IIS, neki drugi ili moe raditi standalone - minimalni web server)

// mi inaæe neæemo raditi ovako,
// mi æemo raditi od punog template-a koji postavlja osnovne komponente koje nam gotovo uvijek trebaju
// .NET Core se sastoji od nekoliko nekakvih poèetnih datoteka koje su u .json formatu
// sami program je napravljen u datoteci Program.cs
// tu imamo metodu Main koja se izvršava po pokretanju tog programa
// podigne se unutarnji server i spreman je da odgovara na zahtjeve


namespace BareCoreProject
{
    public class Program
    {
        // main matoda koja ubiti pokreæe proces
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // ovdje tu kae da æe startati naš interni web server
        // tu moemo imati minimalni web server koji moe biti standalone
        // bez IIS ili nekog drugog web servera
        // poeljno je da u produkciji koristit neki jaèi web server
        // koji radi kao reverse proxy - prima zahtjeve korisnika 
        // i prosljeğuje prema našem script-u

        // tu kae: digni naš server na nekakve defaultne portove (vidi: launchSettings.json)
        // kod nas ubiti diemo IIS, kod nas moe biti i standalone
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); // Startup.cs
                });
    }
}

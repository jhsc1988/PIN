using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// kontroleri, ukoliko ne naðu ništa, vraæaju error 404 -> u sluèaju kada imamo wwwroot
// kada ne naðe ništa u kontrolerima, ide u wwwroot
// i gleda da li postoji folder sa takvom putanjom i nalazi li se tamo nekakav resurs
// wwwroot folder je javno objavljen (wwwroot - oznaèava nekakav standardni poèetni folder aplikacije)
// wwwroot je statièki folder -> fajlovi se šalju prema klijentu (onakvi kakvi jesu)

// Models -> možemo raditi sa bilo kojom bazom podataka
// veæinom radimo sa SQL Serverom

// Views ima Home folder (pripada Home kontroleru) i Shared (nije povezan sa kontrolerom) - ima 
// neke zajednièke fajlove

// interni web server od VS je Kestrel

namespace MVCCoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

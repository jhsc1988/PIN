using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// kontroleri, ukoliko ne na�u ni�ta, vra�aju error 404 -> u slu�aju kada imamo wwwroot
// kada ne na�e ni�ta u kontrolerima, ide u wwwroot
// i gleda da li postoji folder sa takvom putanjom i nalazi li se tamo nekakav resurs
// wwwroot folder je javno objavljen (wwwroot - ozna�ava nekakav standardni po�etni folder aplikacije)
// wwwroot je stati�ki folder -> fajlovi se �alju prema klijentu (onakvi kakvi jesu)

// Models -> mo�emo raditi sa bilo kojom bazom podataka
// ve�inom radimo sa SQL Serverom

// Views ima Home folder (pripada Home kontroleru) i Shared (nije povezan sa kontrolerom) - ima 
// neke zajedni�ke fajlove

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

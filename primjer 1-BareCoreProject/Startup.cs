using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BareCoreProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Dependency injection
            
            // ovdje se mo�e injektirati gomila servisa koji �e se izvr�iti samo kada ih trebamo
            // ovo je nekakva servisna mini arhitektura
            // ovdje je rije� o nekakvim objektima koji su singleton tipa (mo�e postojati samo jedan takav objekt)
            // to je u biti objekt koji mo�e izvr�avati neke svoje zadatke
            // tu smo konkretno pokrenuli dio s kontrolerima

            services.AddControllers();  // servis koji �e mi omogu�iti da radim s kontrolerima
                                        // dakle, sada idemo u HomeController.cs

            services.AddControllersWithViews(); // treba mi da mogu koristiti View, gornji services.AddControllers(); u tom slu�aju
                                                // mogu zakomentirati
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        // Configuracija startupa - isto sadr�i par informacija kako da se pona�a
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) // ako smo u development okru�enju, daj mi neki exception page
            {
                app.UseDeveloperExceptionPage(); // ako je nekakav development, onda daj neki exception - samo kad smo u okru�enju developera
                                                 // kada idemo u produkciju, ovo �emo maknut jer sadr�i previ�e informacija za krajnjeg korisnika 
                                                 // koje nam ujedno mo�e na�tetit aplikaciji
            }

            // tu imamo nekakvu konfiguraciju UseRouting() koja povezuje zahtjeve s nekom akcijom
            app.UseRouting();   // routing - tu vidimo �to korisnik ho�e
                                // on je spojen na na� sajt -> svaki na� url spoji s nekom akcijom
                                // a to radi s endpointima
                                // ako je ovo neka po�etna aplikacija - ovdje ne�to napi�i

            app.UseEndpoints(endpoints =>
            {
                // endpoint je nekakva procedura koja �e se izvr�iti kada aktiviramo pojedini URL
                // imamo mogu�nost da radimo s kontrolerima, i donji kod izbacujemo,
                // i mi �emo koristiti posebni nekakav folder gdje su kontroleri,
                // a to su komponente koje odgovaraju na korisni�ke zahtjeve

                endpoints.MapControllers(); // ne�e pro�i, fali mi servis
                                            // da bi mogao mapirati kontroler trebamo dio koda, povezati moj zahtjev
                                            // sa ovim mojim fajlom -> imamo dio koji se zove ConfigureServices
                                            // ovdje u kontrolerima hvatamo endpoint-e
                                            // imamo niz na�ih endpoint-a
                                            // i ka�e ok -> ja ne znam koje sve URL-ove prati�
                                            // ali imam nekakav servis koji �e to mapirati s kontrolerima
                                            // a te kontrolere �emo povezati s na�im Views

                // zakomentiramo da bi koristili na� kontroler
                // korisitmo endopint - to su to�ke aplikacije (dijelovi) na koje se mi spajamo (URL-ovi)
                // dakle, mo�emo aplikaciju zamisliti kao niz URL-ova
                // "/" je zapravo url tog na�eg endpoint-a

                //endpoints.MapGet("/", async context =>
                //{
                //    // po�to jesmo u developmentu, idemo vidjeti �to bi dobili -> idemo baciti neki exception
                //    // throw new Exception("Booom");

                //    await context.Response.WriteAsync("<h1> Predavanje 9 </h1> Pozdrav iz ASP.NET Core");

                // 
                //});

                // zatim, dodamo Controller -> stavimo prazni folder (add - folder (naziva Controller) - u njeg prazni kontroler)
            });
        }
    }
}

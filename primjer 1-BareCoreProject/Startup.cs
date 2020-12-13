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
            
            // ovdje se može injektirati gomila servisa koji æe se izvršiti samo kada ih trebamo
            // ovo je nekakva servisna mini arhitektura
            // ovdje je rijeè o nekakvim objektima koji su singleton tipa (može postojati samo jedan takav objekt)
            // to je u biti objekt koji može izvršavati neke svoje zadatke
            // tu smo konkretno pokrenuli dio s kontrolerima

            services.AddControllers();  // servis koji æe mi omoguæiti da radim s kontrolerima
                                        // dakle, sada idemo u HomeController.cs

            services.AddControllersWithViews(); // treba mi da mogu koristiti View, gornji services.AddControllers(); u tom sluèaju
                                                // mogu zakomentirati
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        // Configuracija startupa - isto sadrži par informacija kako da se ponaša
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) // ako smo u development okruženju, daj mi neki exception page
            {
                app.UseDeveloperExceptionPage(); // ako je nekakav development, onda daj neki exception - samo kad smo u okruženju developera
                                                 // kada idemo u produkciju, ovo æemo maknut jer sadrži previše informacija za krajnjeg korisnika 
                                                 // koje nam ujedno može naštetit aplikaciji
            }

            // tu imamo nekakvu konfiguraciju UseRouting() koja povezuje zahtjeve s nekom akcijom
            app.UseRouting();   // routing - tu vidimo što korisnik hoæe
                                // on je spojen na naš sajt -> svaki naš url spoji s nekom akcijom
                                // a to radi s endpointima
                                // ako je ovo neka poèetna aplikacija - ovdje nešto napiši

            app.UseEndpoints(endpoints =>
            {
                // endpoint je nekakva procedura koja æe se izvršiti kada aktiviramo pojedini URL
                // imamo moguænost da radimo s kontrolerima, i donji kod izbacujemo,
                // i mi æemo koristiti posebni nekakav folder gdje su kontroleri,
                // a to su komponente koje odgovaraju na korisnièke zahtjeve

                endpoints.MapControllers(); // neæe proæi, fali mi servis
                                            // da bi mogao mapirati kontroler trebamo dio koda, povezati moj zahtjev
                                            // sa ovim mojim fajlom -> imamo dio koji se zove ConfigureServices
                                            // ovdje u kontrolerima hvatamo endpoint-e
                                            // imamo niz naših endpoint-a
                                            // i kaže ok -> ja ne znam koje sve URL-ove pratiš
                                            // ali imam nekakav servis koji æe to mapirati s kontrolerima
                                            // a te kontrolere æemo povezati s našim Views

                // zakomentiramo da bi koristili naš kontroler
                // korisitmo endopint - to su toèke aplikacije (dijelovi) na koje se mi spajamo (URL-ovi)
                // dakle, možemo aplikaciju zamisliti kao niz URL-ova
                // "/" je zapravo url tog našeg endpoint-a

                //endpoints.MapGet("/", async context =>
                //{
                //    // pošto jesmo u developmentu, idemo vidjeti što bi dobili -> idemo baciti neki exception
                //    // throw new Exception("Booom");

                //    await context.Response.WriteAsync("<h1> Predavanje 9 </h1> Pozdrav iz ASP.NET Core");

                // 
                //});

                // zatim, dodamo Controller -> stavimo prazni folder (add - folder (naziva Controller) - u njeg prazni kontroler)
            });
        }
    }
}

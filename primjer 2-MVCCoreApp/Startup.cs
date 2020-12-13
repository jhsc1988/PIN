using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles(); // ako ne mogu prona�i kontroler, provjeri nalazi li se u stati�kim fajlovima (.css, .js, .ico ...)

            app.UseRouting(); // pove�i URL s na�im kontrolerima (HomeControllers.cs)
                              // onaj [HttpGet] vi�e ne�emo stavljat jer imamo routing
                              // dakle, postoji logika kojom se povezuje URL sa metodama kontrolera
                              // to se radi sa Endpoint

            app.UseAuthorization(); // autorizacija, za sada se necemo time baviti

            app.UseEndpoints(endpoints =>
            {
                // koristi endpointe i mapiraj rute 
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                // prvi dio je kontroler, drugi dio akcija, {id?} je parametar, odnosno neki podatak
                // ako nema kontrolera, defaultni je home
                // ako je samo /, zna�i nisam zadao kontroler, po�etna stranica je u Home kontroleru (??)
            });
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 //For EF:
using Microsoft.EntityFrameworkCore;
using ShahbazWebsite_MVCPlatform.Models;


namespace ShahbazWebsite_MVCPlatform
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
            
            // Adding: Cookie-based TempData provider
            // > "In ASP.NET Core 2.0 and later, the cookie-based TempData provider is used by default to store TempData in cookies."
            // Via: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state

                services.AddMvc()
                 .AddSessionStateTempDataProvider();

              services.AddSession();

            // Adding: DB Context to be registered and used throughout web app

            // Azure DB link:
            var connection = @"Server=Provider=SQLNCLI11.1;Data Source=tcp:comp313mvcdatabaseserver.database.windows.net;User ID=mudrak;Initial Catalog=comp313MVCDatabase;Password=Password@123";

             services.AddDbContext<comp313MVCDatabaseContext>(options => options.UseSqlServer(connection));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            // Adding: Cookie-based TempData provider
            // > "In ASP.NET Core 2.0 and later, the cookie-based TempData provider is used by default to store TempData in cookies."
            // Via: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state

            app.UseSession();

            // -------------------------------------------------------------------------

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
       
                // Default route setup by Visual Studio:
                // Controller:Home, Action:Index

                //    routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Home}/{action=Index}/{id?}");


                // NEW default route for our app:
                // Controller:Login, Action:Login

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Login}");

            });
        }
    }
}

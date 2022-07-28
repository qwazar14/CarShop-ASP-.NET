using System;
using GoshaDudarExampleShop.Data;
using GoshaDudarExampleShop.Data.Interfaces;
using GoshaDudarExampleShop.Data.Mocks;
using GoshaDudarExampleShop.Data.Models;
using GoshaDudarExampleShop.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoshaDudarExampleShop
{
    public class Startup
    {
        private readonly IConfigurationRoot _configurationRoot;

        public Startup(IHostEnvironment hostEnv)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath)
                .AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContent>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            ;
            services.AddTransient<ICar, CarRepository>();
            services.AddTransient<ICategory, CategoryRepository>();
            // services.AddTransient<ICar, MockCar>();
            // services.AddTransient<ICategory, MockCategory>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(ShopCart.GetCart);

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                // routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}",
                //     defaults: new { Controller = "Car", action = "List" });
                routes.MapRoute(name: "CategoryFilter", template: "{controller=Cars}/{action}/{category?}"); //, defaults: new { Controller = "Cars", action = "List" }
            });
            // app.UseMvcWithDefaultRoute();
            


            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContent>();
            DbObjects.Initialize(context);
        }
    }
}
using System;
using GoshaDudarExampleShop.Data;
using GoshaDudarExampleShop.Data.Interfaces;
using GoshaDudarExampleShop.Data.Mocks;
using GoshaDudarExampleShop.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            ;
            services.AddTransient<ICar, CarRepository>();
            services.AddTransient<ICategory, CategoryRepository>();
            // services.AddTransient<ICar, MockCar>();
            // services.AddTransient<ICategory, MockCategory>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                DbObjects.Initialize(context);
            }
        }
    }
}
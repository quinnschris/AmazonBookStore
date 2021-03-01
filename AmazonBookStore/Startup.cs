using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonBookStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AmazonBookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:AmazonBookstoreConnection"]);
            });

            services.AddScoped<IBookstoreRepository, EFBookStoreRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Endpoint with both page and category
                endpoints.MapControllerRoute("categorypage",
                    "{category}/{page:int}",
                    new { Controller = "Home", action = "Index" });

                // Endpoint with only page
                endpoints.MapControllerRoute("page",
                    "{page:int}",
                    new { Controller = "Home", action = "Index" });

                // Endpoint with only category
                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index" });

                // Endpoint when user is referencing specific BookInfos on a page created
                endpoints.MapControllerRoute("pagination",
                    "BookInfos/P{page}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday.DataBaseContext;
using Holiday.Repositories;
using Holiday.Repositories.Interfaces;
using Holiday.Services;
using Holiday.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Holiday
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
            services.AddRazorPages();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<HolidayContext>();
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;

            });
            var connection = @"Server = (localdb)\mssqllocaldb;Database=Holiday;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<HolidayContext>
                (options => options.UseSqlServer(connection));
            services.AddScoped(typeof(IRepositoryWrapper), typeof(RepositoryWrapper));
            services.AddScoped<IVacantion, VacantionService>();
            services.AddScoped<IEmployee, EmployeeService>();
            services.AddScoped<IVacantionRequest, VacantionRequestService>();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}

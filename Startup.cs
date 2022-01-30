using BellaPizza.Models;
using BellaPizza.Models.Context;
using BellaPizza.Models.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza
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

            services.AddDistributedMemoryCache(); //before AddControllersWithViews

            services.AddControllersWithViews()
                .AddSessionStateTempDataProvider()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddDbContext<BellaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BellaStr")));

            services.AddIdentity<AppUser, IdentityRole>(identityoption =>
            {

                identityoption.Password.RequireDigit = true;
                identityoption.Password.RequiredLength = 8;
                identityoption.Password.RequireLowercase = true;
                identityoption.Password.RequireUppercase = true;
                identityoption.Password.RequiredUniqueChars = 1;

                identityoption.User.RequireUniqueEmail = true;

                identityoption.Lockout.MaxFailedAccessAttempts = 5;
                identityoption.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                identityoption.Lockout.AllowedForNewUsers = true;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<BellaContext>();

            services.AddTransient<AppDetail>();

            services.AddHttpContextAccessor();


            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            //services.AddRazorPages();
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
                app.UseExceptionHandler("Manage/Dashboard/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Dashboard}/{action=Dashboard}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");



                //endpoints.MapRazorPages();
            });
        }
    }
}

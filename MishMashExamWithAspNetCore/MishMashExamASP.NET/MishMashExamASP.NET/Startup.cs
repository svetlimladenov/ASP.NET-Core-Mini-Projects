using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using MishMashExamASP.NET.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MishMashExamASP.NET.Data.Models;
using MishMashExamASP.NET.Filters;
using MishMashExamASP.NET.Middlewares;
using MishMashExamASP.NET.ModelBinders;
using MishMashExamASP.NET.Services;
using MishMashExamASP.NET.Services.Channels;
using MishMashExamASP.NET.Services.Users;

namespace MishMashExamASP.NET
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<MishMashUser,IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(0, new DateTimeToYearModelBinderProvider());
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                options.Filters.Add(new AddCustomHeaderOnExeptionFilterAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                


            //services
            services.AddScoped<IChannelServices, ChannelServices>();
            services.AddTransient<IUserServices, UserServices>();


            services.AddScoped<ICounterService, CounterService>();
            services.AddTransient<MyAuthorizeFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions()
                {
                    SourceCodeLineCount = 50
                }); 
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMiddleware<SeedRolesMiddleware>();

            app.Use( async (context, next) =>
            {
                var username = context.User.Identity.Name;
                if (username != null)
                {
                    context.Response.Cookies.Append("Username", username, options: new CookieOptions() { HttpOnly = true});
                }
                await next();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRHDipComp_Project.Models.Database;
using TRHDipComp_Project.Models.Messaging;

namespace TRHDipComp_Project
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

            // this will extract the Twilio account details from the appsettings.json and map them to an object
            services.Configure<TwilioAccount>(Configuration.GetSection("TwilioAccount"));

            //Add http client services 
            services.AddHttpClient();

            // Add Db context to services - in memory DB
            // temp DB option
            // services.AddDbContext<CollegeDbContext>(options => options.UseInMemoryDatabase("tempCollegeDB"));

            // Local DB option - CollegeDBContext
            // services.AddDbContext<CollegeDbContext>(options => options.UseSqlServer(
            //    Configuration.GetConnectionString("CollegeTestDBContext")));

            // Azure SQL Server service - HDipCompTRproject_DB
            services.AddDbContext<CollegeDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("HDipCompTRproject_DB")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/MyErrorPage");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseExceptionHandler("/MyErrorPage");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
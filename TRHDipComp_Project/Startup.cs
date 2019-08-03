using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TRHDipComp_Project.Models;

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

            // Configure service to add authentication based on JWT tokens 
            // Jwt is the default authentication scheme
            // 
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Site"],
                    ValidIssuer = Configuration["Jwt:Site"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });


            // Add Identity User and IdentityRole to the identity service registration
            // Is token based authentication
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AuthenticationDbContext>()
                    .AddDefaultTokenProviders();

            // Configure the rules that govern how the Identity Framework is used
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789&£$-._@+";
                options.User.RequireUniqueEmail = false;
            });



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add Db context to services - in memory DB
            // temp DB option
            // services.AddDbContext<CollegeDbContext>(options => options.UseInMemoryDatabase("tempCollegeDB"));

            // Local DB option - CollegeDBContext
            services.AddDbContext<CollegeDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("CollegeTestDBContext")));


            // Local DB option - AuthenticationDBContext
            services.AddDbContext<AuthenticationDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("AuthenticationCollegeDBContext")));


            // Azure SQL Server service - HDipCompTRproject_DB
            // services.AddDbContext<CollegeDbContext>(options => options.UseSqlServer(
            //    Configuration.GetConnectionString("HDipCompTRproject_DB")));

            //Ensure threadsafe code - validation code especially
            services.AddDbContext<CollegeDbContext>(ServiceLifetime.Transient);
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
                // Use custom MyErrorPage in production
                app.UseExceptionHandler("/MyErrorPage");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // Use JWT token based authentication configured in ConfigureServices
            app.UseAuthentication();
            app.UseMvc();

            /* - omit for now
            app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}");
                }
            );
            */
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Motorsport1.Data;
namespace Motorsport1.Web
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Motorsport1.Services.Data.Interfaces;
    using Motorsport1.Services.Data;
    using Motorsport1.Web.Infrastructure.Extensions;
    using Motorsport1.Web.Infrastructure.ModelBinders;
    using Microsoft.AspNetCore.Mvc;

    using static Common.GeneralApplicationConstants;
    using Motorsport1.Services.Mapping;
    using Motorsport1.Web.ViewModels.Home;
    using System.Reflection;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");    
            
            builder.Services.AddDbContext<Motorsport1DbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = 
                    builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireLowercase = 
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireDigit =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireDigit");
                options.Password.RequireNonAlphanumeric =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredLength =
                    builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<Motorsport1DbContext>();

            builder.Services.AddApplicationServices(typeof(IArticleService));

            builder.Services.AddRecaptchaService();

            builder.Services.AddMemoryCache();

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/User/Login";
            });

            builder.Services
                .AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.ModelBinderProviders.Insert(1, new DoubleModelBinderProvider());
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            WebApplication app = builder.Build();

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.EnableOnlineUsersCheck();

            app.SeedAdministrator(DevelopmentAdminEmail);
            app.CreatePublisher(DevelopmentPublisherEmail);

            app.UseEndpoints(config =>
            {
                config.MapControllerRoute(
                    name: "areas",
                    pattern: "/{area:exists}/{controller=Home}/{action=Index}/{Id?}"
                );
                app.MapDefaultControllerRoute();
                app.MapRazorPages();
            });

            await app.RunAsync();
        }
    }
}
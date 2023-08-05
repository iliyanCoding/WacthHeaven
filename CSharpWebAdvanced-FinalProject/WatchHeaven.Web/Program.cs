
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WatchHeaven.Data.Model;
using WatchHeaven.Services.Data;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Data;
using WatchHeaven.Web.Infrastructure.ModelBinders;
using static WatchHeaven.Common.GeneralApplicationConstants;

namespace WatchHeaven.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<WatchHeavenDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount
                    = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireNonAlphanumeric
                    = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequireLowercase
                    = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase
                    = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequiredLength
                    = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");

            })
                .AddRoles<IdentityRole<Guid>>()
               .AddEntityFrameworkStores<WatchHeavenDbContext>();

            builder.Services.AddApplicationServices(typeof(IWatchService));

            builder.Services.AddRecaptchaService();

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/User/Login";
            });

            builder.Services.AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            var app = builder.Build();

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

            app.SeedAdmin(DevelopmentAdminEmail);

            app.UseEndpoints(config =>
            {
                config.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                config.MapDefaultControllerRoute();
                config.MapRazorPages();
            });

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}
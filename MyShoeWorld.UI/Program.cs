using MyShoeWorld.Models;
using MyShoeWorld.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication;
using Auth0.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace MyShoeWorld.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //var builder = WebApplication.CreateBuilder(args);
            ////builder.Configuration.GetConnectionString("MyShoeWorldConStr");
            //    // this config obj cabable of reading anaything from appsetting.json file 

            //// Add services to the container.
            //builder.Services.AddControllersWithViews();
            //builder.Services.AddDbContext<MyShoeWorldDbContext>
            //    (options=>options.UseSqlServer(builder.Configuration.GetConnectionString("MyShoeWorldConStr")));

            //builder.Services.AddTransient<IShoeWorldRepository<Product>,
            //    IShoeWorldRepository<Product>>();

            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}


            var builder = WebApplication.CreateBuilder(args);
            //

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
                .AddFacebook(options =>
                {
                    IConfigurationSection FBAuthNSection =
                    builder.Configuration.GetSection("Authentication:Facebook");
                    options.AppId = FBAuthNSection["ClientId"];
                    options.AppSecret = FBAuthNSection["ClientSecret"];
                })
               .AddGoogle(options =>
               {
                   IConfigurationSection googleAuthNSection =
                   builder.Configuration.GetSection("Authentication:Google");
                   options.ClientId = googleAuthNSection["ClientId"];
                   options.ClientSecret = googleAuthNSection["ClientSecret"];
                   options.ClaimActions.MapJsonKey("urn:google:picture", "picture");
                   options.ClaimActions.MapJsonKey("urn:google:email", "email");
               })
               .AddAuth0WebAppAuthentication(options =>
               {
                   options.Domain = builder.Configuration["Authentication:Auth0:Domain"];
                   options.ClientId = builder.Configuration["Authentication:Auth0:ClientId"];
                   options.Scope = "openid profile email";
               });
            //facebook
            //.AddAuth0WebAppAuthentication(options =>
            // {
            //     options.Domain = builder.Configuration["Authentication:Auth0:Domain"];
            //     options.ClientId = builder.Configuration["Authentication:Auth0:ClientId"];
            //     options.Scope = "openid profile email";
            // });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MyShoeWorldDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyShoeWorldConStr")));
            // using above line DB context added to the container
            //builder.Services.AddTransient<IShoeWorldRepository<Product>, ShoeWorldRepository<Product>>();
            // using above the shoeworldrepository of type product is added in container and we can use this using DI
            // annalogy :- choclate wrapper example 
            // services is basically a container 
            //singleton :- only one isntance is created throughout life 
            //builder.Services.AddTransient<IShoeWorldRepository<Category>, ShoeWorldRepository<Category>>();
            //builder.Services.AddTransient<IShoeWorldRepository<Customer>, ShoeWorldRepository<Customer>>();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = new TimeSpan(50, 20, 0);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            // Add services to the container.

            builder.Services.AddApplicationServices();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
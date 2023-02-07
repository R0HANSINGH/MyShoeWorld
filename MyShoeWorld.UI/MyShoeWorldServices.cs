using MyShoeWorld.Dal;
using MyShoeWorld.Models;
namespace MyShoeWorld.UI
{
    public static class MyShoeWorldServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<IShoeWorldRepository<Product>, ShoeWorldRepository<Product>>();
            services.AddTransient<IShoeWorldRepository<Category>, ShoeWorldRepository<Category>>();
            services.AddTransient<IShoeWorldRepository<Customer>, ShoeWorldRepository<Customer>>();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = new TimeSpan(0, 20, 0);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            return services;
        }
    }
}
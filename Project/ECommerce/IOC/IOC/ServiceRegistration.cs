// IOC/ServiceRegistration.cs
using BLL.Services.Abstracts;
using BLL.Services.Concretes;
using DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOC
{
    public static class ServiceRegistration
    {
        public static void AddIdentityResolver(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // 1. DbContext kaydı
            services.AddDbContext<ProjectContext>(options =>
                options.UseSqlServer(connectionString));

            // 2. Identity kaydı
            //kullanıcı oluşturulurken tayin edilecek şifrenin özelleştirilmesi.
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<ProjectContext>()
            .AddDefaultTokenProviders();

            // 3. Cookie ayarları (eski dosyadan kopyalandı)
            services.ConfigureApplicationCookie(cookie =>
            {
                cookie.LoginPath = new PathString("/Home/Login");
                cookie.AccessDeniedPath = new PathString("/Home/Denied");
                cookie.Cookie = new CookieBuilder { Name = "yzl3447_cookie" };
                cookie.SlidingExpiration = true;
                cookie.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            });

            // 4. UserServiceManager (eski dosyadan kopyalandı)
            services.AddScoped<IUserServiceManager, UserServiceManager>();
        }
    }
}
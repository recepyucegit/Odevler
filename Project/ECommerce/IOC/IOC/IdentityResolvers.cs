//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;

//using DAL.Context;
//using Microsoft.AspNetCore.Http;
//using BLL.Services.Abstracts;
//using BLL.Services.Concretes;

//namespace IOC
//{
//    public static class IdentityResolvers
//    {
//        //Identity Servisler için aşağıdaki static metot kullanılır.
//        public static IServiceCollection AddIdentityResolver(this IServiceCollection services)
//        {


//            //UserServiceManager 

//            services.AddScoped<IUserServiceManager, UserServiceManager>();





//            //Identity Service
//            services.AddIdentity<IdentityUser, IdentityRole>()
//                .AddEntityFrameworkStores<ProjectContext>().AddDefaultTokenProviders();// Token sağlayıcılarını ekliyoruz;

//            //Configure Identity options
//            //cookie settings
//            services.ConfigureApplicationCookie(cookie =>
//            {
//                cookie.LoginPath = new PathString("/Home/Login");
//                cookie.AccessDeniedPath = new PathString("/Home/Denied");
//                cookie.Cookie = new CookieBuilder { Name = "yzl3447_cookie" };
//                cookie.SlidingExpiration = true;
//                cookie.ExpireTimeSpan = TimeSpan.FromMinutes(5);
//            });

//            return services;
//        }
//    }
//}

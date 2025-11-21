using BLL.Services.Abstracts;
using BLL.Services.Concretes;
using DAL.Context;
using DAL.Repositories.Abstracts;
using DAL.Repositories.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public static class BusinesServiceResolvers
    {
        public static IServiceCollection AddBllResolver(this IServiceCollection services, IConfiguration configuration)
        {
            //AddDbContext

            //appsettings.json içerisinde bulunan herhangi bir anahtar (key) ulaşmak istiyorsak bunu builder içerisine bulunan Configuration property'ni kullanabiliriz.

            //string connectionString = configuration.GetConnectionString("LocalConnection");

            //services.AddDbContext<ProjectContext>(options => options.UseSqlServer(connectionString));

            //SERVICES
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
           services.AddScoped(typeof(IServiceManager<>), typeof(ServiceManager<>));

            services.AddScoped<ICategoryServiceManager, CategoryServiceManager>();
            services.AddScoped<IProductServiceManager, ProductServiceManager>();
            services.AddScoped<IOrderServiceManager, OrderServiceManager>();
            services.AddScoped<IOrderDetailServiceManager, OrderDetailServiceManager>();
            services.AddScoped<IShipperServiceManager, ShipperServiceManager>();
            services.AddScoped<ISupplierServiceManager, SupplierServiceManager>();

            return services;
        }
    }
}

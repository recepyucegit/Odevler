using Application.Repositories;
using Application.ServiceManager;
using Infrastructure.Persistance;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.DependencyResolvers
{
    public class DependencyResolver
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // ============================================
            // DATABASE
            // ============================================
            services.AddDbContext<NorthwindDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FatihConnection")));

            // ============================================
            // SESSION CONFIGURATION
            // ============================================
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Name = ".NorthwindApp.Session";
            });

            // ============================================
            // IDENTITY CONFIGURATION
            // ============================================
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // Şifre gereksinimleri
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;

                // Kullanıcı gereksinimleri
                options.User.RequireUniqueEmail = true;

                // Hesap kilitleme
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
            .AddEntityFrameworkStores<NorthwindDbContext>()
            .AddDefaultTokenProviders();

            // ============================================
            // JWT AUTHENTICATION
            // ============================================
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Token doğrulama kuralları
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ClockSkew = TimeSpan.Zero // Token süresi dolduysa anında geçersiz olsun
                };
            });

            // ============================================
            // CORS
            // ============================================
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // ============================================
            // REPOSITORIES
            // ============================================
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // ============================================
            // SERVICE MANAGERS
            // ============================================
            services.AddScoped<CategoryServiceManager>();
            services.AddScoped<SupplierServiceManager>();   // Supplier tarafındaki yeni davranış burada kullanılacak
            services.AddScoped<ProductServiceManager>();
            services.AddScoped<UserServiceManager>();
            services.AddScoped<CartServiceManager>();
        }
    }
}

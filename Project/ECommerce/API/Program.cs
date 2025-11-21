

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Business Logic Layer servisleri ekle
builder.Services.AddBllResolver(builder.Configuration);
builder.Services.AddIdentityResolver(builder.Configuration);
// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });

    options.AddPolicy("AllowSpecificOrigins",
    builder =>
    {
        builder.WithOrigins(
                "http://localhost:5500",   // Live Server varsayýlaný
                "http://127.0.0.1:5500",
                "http://localhost:3000",
                "http://localhost:3001",
                "http://localhost:3002",
                "https://localhost:7046",
                "http://localhost:5000")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials(); // credentials varsa gerekli
    });
});

// JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        ClockSkew = TimeSpan.Zero
    };
});

// Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanAddProduct", policy =>
        policy.RequireClaim("Permission", "AddProduct"));

    options.AddPolicy("CanEditProduct", policy =>
        policy.RequireClaim("Permission", "EditProduct"));

    options.AddPolicy("CanDeleteProduct", policy =>
        policy.RequireClaim("Permission", "DeleteProduct"));
});

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "E-Commerce Supplier API",
        Version = "v1",
        Description = "Bayiler için E-Ticaret API",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "API Support",
            Email = "support@ecommerce.com"
        }
    });

    // JWT için Swagger ayarlarý
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce Supplier API V1");
        c.RoutePrefix = string.Empty; // Swagger'ý root'ta aç
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // Development için, production'da "AllowSpecificOrigins" kullanýn

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// API Welcome endpoint
app.MapGet("/", () => Results.Ok(new
{
    message = "E-Commerce Supplier API",
    version = "1.0",
    documentation = "/swagger",
    endpoints = new
    {
        auth = "/api/auth/login",
        supplierInfo = "/api/auth/supplier-info",
        products = "/api/product",
        categories = "/api/product/categories"
    }
}));

app.Run();

// ==========================================
// API/APPSETTINGS.JSON
// ==========================================
/*
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=Yzl3447_ProjectDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "ThisIsMyVerySecretKeyForJWTTokenGeneration2024!",
    "Issuer": "ECommerceAPI",
    "Audience": "SupplierClients",
    "ExpirationInMinutes": 60
  }
}
*/
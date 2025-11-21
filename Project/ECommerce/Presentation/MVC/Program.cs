using BLL.Services.Abstracts;
using BLL.Services.Concretes;
using DAL.Configurations.Concretes;
using DAL.Context;
using DAL.Repositories.Abstracts;
using DAL.Repositories.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IOC;



//#8 için oluþturulan yorum.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddBllResolver(builder.Configuration);


// ? DOÐRU
builder.Services.AddIdentityResolver(builder.Configuration);


//Session Service
builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(2);
    x.Cookie = new CookieBuilder
    {
        Name = "sepet_session"
    };
});



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
app.UseSession();
app.UseRouting();


app.UseAuthentication();//kimlik doðrulama
app.UseAuthorization();//yetki




//Dashboard Area Route
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

//Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

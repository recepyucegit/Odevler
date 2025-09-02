using MVC_CodeFirst.Repositories.Abstracts;
using MVC_CodeFirst.Repositories.Concretes;
using MVC_CodeFirst.Services.Abstracts;
using MVC_CodeFirst.Services.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Proje i�erisinde kullan�lacak custom servisler a�a��dad�r�.
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();


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

app.UseAuthorization();


//D��ar�da kalan homecontroller'a ula��m i�in dahil edildi.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Area i�erisinde bulunan homecontroller'a ula��m i�in dahil edildi.
app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.Run();

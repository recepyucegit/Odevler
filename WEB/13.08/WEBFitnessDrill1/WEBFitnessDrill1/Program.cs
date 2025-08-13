WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

//wwwroot klasörüne dýþarýdan (browser) ulaþýlmasýna  izin verilmesi gerekmektedir.


app.UseDefaultFiles();//varsayýlan olarak wwwroot içerisinde bulunan index.html açýlacak.
app.UseStaticFiles(); //wwwroot dýþarýdan ulaþýlabilir hale gelir.




app.Run();
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

//wwwroot klas�r�ne d��ar�dan (browser) ula��lmas�na  izin verilmesi gerekmektedir.

app.UseStaticFiles(); //wwwroot d��ar�dan ula��labilir hale gelir.

app.Run();

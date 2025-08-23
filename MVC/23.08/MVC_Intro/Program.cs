//AspNet Core Empty

//Services
var builder=WebApplication.CreateBuilder(args);
//Ekstra eklemek istedi�imiz servisler olacaksa o halde builder.Services.Add() metodu kullanarak birden fazla servis dahil edebiliriz.


//MVC Servisi
//.AddMvc();
//.AddControllersWithViews();
builder.Services.AddControllersWithViews();

//Applications
var app =builder.Build();

//Route
//app.MapGet("/", ()=>
//{

//    //Log kay�tlar�
//    Console.WriteLine("sayfa a��ld�!");
//});

//app.MapGet("/about", () =>
//{

//    //Log kay�tlar�
//    Console.WriteLine("hakk�m�zda sayfa a��ld�!");
//});

//app.MapGet("/contact", () =>
//{

//    //Log kay�tlar�
//    Console.WriteLine("ileti�im sayfas� a��ld�!");
//});


//Routing
app.UseRouting(); //url isteklerini ilgili controller'lara y�nlendirmek i�in

app.UseEndpoints(x =>
{
    x.MapDefaultControllerRoute();
    //https://localhost:7036/Home/Index
    //https://localhost:7036/Product/Index

    //ilk parametre Controller parametresidir.
    //ikinci parametre metot parametresidir.


});


app.Run();


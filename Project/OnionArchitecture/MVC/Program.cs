using Infrastructure.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// ============================================
// MVC CONFIGURATION
// ============================================
builder.Services.AddControllersWithViews();

// ============================================
// DEPENDENCY INJECTION
// ============================================
DependencyResolver.RegisterServices(builder.Services, builder.Configuration);

var app = builder.Build();

// ============================================
// MIDDLEWARE PIPELINE
// ============================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// CORS (API kullanýmý için)
app.UseCors("AllowAll");

// SESSION - Mutlaka UseRouting() ve UseAuthorization() arasýnda olmalý!
app.UseSession();

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// ============================================
// ROUTING
// ============================================

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
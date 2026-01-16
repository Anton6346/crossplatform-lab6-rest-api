using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

/* ?? AUTHENTICATION */
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = "1060867696884-amjvglhqrr8ml9n3pj3ciedn8rvnueum.apps.googleusercontent.com";
    options.ClientSecret = "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";
});

/* ?? DATABASE */
// 1. ќтримуЇмо назву провайдера з конф≥гурац≥њ
var provider = builder.Configuration.GetValue<string>("DatabaseProvider");

// 2. –еЇструЇмо DbContext залежно в≥д обраного провайдера
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    if (provider == "Sqlite")
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
    }
    else if (provider == "Postgres")
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
    }
    else
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
    }
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // ? ќЅќ¬?я« ќ¬ќ
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// ===== AUTHENTICATION & AUTHORIZATION =====
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = "Google";
})
.AddCookie(options =>
{
    options.LoginPath = "/Account/Login";
})
.AddGoogle("Google", options =>
{
    options.ClientId = "1060867696884-amjvglhqrr8ml9n3pj3ciedn8rvnueum.apps.googleusercontent.com";
    options.ClientSecret = "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";
});

builder.Services.AddAuthorization();

var app = builder.Build();

// ===== MIDDLEWARE =====
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// ===== ROUTING =====
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

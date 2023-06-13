using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.DataBase;
using WebApplication1.DataBase.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IDataBaseContext, PostgresContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetSection("DataBase").Value);
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.LoginPath = "/Public/Login";
        options.AccessDeniedPath = "/Home/Index";    
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", builder => 
    {
        builder.RequireClaim(ClaimTypes.Role, "admin");
    });

    options.AddPolicy("admin", builder =>
    {
        builder.RequireClaim(ClaimTypes.Role, "user");
    });
});

builder.Services.AddControllersWithViews();

builder.Services.AddMemoryCache();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
using Common.Application;
using Config;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
services.AddRazorPages();
var ConnectionString = builder.Configuration.GetConnectionString("Default");
if (ConnectionString is null)
    throw new NullReferenceException("ConnectionString is null");
Bootstrapper.ConfigBootstrapper(services, ConnectionString);
ValidationBootstrapper.Init(services);

//builder.Services.AddAuthorization(option =>
//{
//    option.AddPolicy("AdminPolicy", builder =>
//    {
//        builder.RequireRole("admin");
//    });
//});

//builder.Services.AddAuthentication(option =>
//{
//    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

//}).AddCookie(option =>
//{
//    option.LoginPath = "/Authorize/Signin";
//    option.LogoutPath = "/Authorize/Signout";
//    option.ExpireTimeSpan = TimeSpan.FromDays(30);
//    option.AccessDeniedPath = "/";
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();

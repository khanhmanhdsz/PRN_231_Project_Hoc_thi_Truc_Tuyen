using WebClient.Config;
using WebClient.Filters;
using WebClient.Middlewares;
using WebClient.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDistributedMemoryCache(); // Use a distributed cache for session data

builder.Services.AddSession();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication((options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}))
.AddCookie(options =>
{
    options.LoginPath = "/SignIn";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/Error/Error403";
});


builder.Services.AddHttpContextAccessor();

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// Services
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<GoogleDriveService>();
// Filters
//builder.Services.AddScoped<PublicPageFilter>();

// Transient

builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();

// Mapper
var mapper = AutoMapperConfig.Initialize();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler("/Error");
app.UseStatusCodePagesWithRedirects("/Error/Error404");


//app.Use(async (context, next) =>
//{
//    context.Response.OnStarting(state =>
//    {
//        // Remove Server header from HTTP response headers
//        context.Response.Headers.Remove("Server");

//        // Remove X-Powered-By header from HTTP response headers
//        context.Response.Headers.Remove("X-Powered-By");

//        return Task.CompletedTask;
//    }, context);

//    // Add the X-Frame-Options header to HTTP response headers.
//    context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");

//    // Add the X-Content-Type-Options header to HTTP response headers.
//    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");

//    // Set Content-Security-Policy header
//    context.Response.Headers.Add("Content-Security-Policy", "");


//    // Set Permissions-Policy header
//    context.Response.Headers.Add("Permissions-Policy", "geolocation=()");


//    await next();
//});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

// Configure middleware
//app.UseMiddleware<SessionExpirationMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

// Configure role-based routing
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
       name: "Admin",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
   );

    endpoints.MapControllerRoute(
       name: "Student",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
   );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});

app.Run();

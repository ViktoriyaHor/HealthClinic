using HealthClinic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

Env.Load();
// Retrieve environment variables
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var certificatePassword = Environment.GetEnvironmentVariable("CERTIFICATE_PASSWORD");

var builder = WebApplication.CreateBuilder(args);

// Replace placeholders in configuration
var connectionString = builder.Configuration["ConnectionStrings:HealthClinicDbContext"];
if (!string.IsNullOrEmpty(connectionString))
{
    builder.Configuration["ConnectionStrings:HealthClinicDbContext"] = 
        connectionString.Replace("{DB_USER}", dbUser)
                        .Replace("{DB_PASSWORD}", dbPassword);
}
else
{
    throw new InvalidOperationException("Connection string 'HealthClinicDbContext' is not found in configuration.");
}

builder.Configuration["Kestrel:Endpoints:Https:Certificate:Password"] = certificatePassword;

builder.Services.AddDbContext<HealthClinicDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HealthClinicDbContext")));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<HealthClinicDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(opts =>
{
    opts.User.RequireUniqueEmail = true;
});
builder.Services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Authenticate/Login");
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = ".AspNetCore.Identity.Application";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.SlidingExpiration = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

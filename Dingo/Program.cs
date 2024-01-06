using BusinessLayer.DependencyResolvers;
using DataAccessLayer.Concrete;
using DataAccessLayer.Mappers.AutoMapper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.BusinessLoad();
builder.Services.AddAutoMapper(typeof(DtoMapper));

builder.Services.AddMemoryCache();

builder.Services.AddIdentity<AppUser, AppRole>(Identityoptions =>
{
    Identityoptions.User.RequireUniqueEmail = true;
    Identityoptions.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
    Identityoptions.Password.RequiredLength = 8;
    Identityoptions.Password.RequireNonAlphanumeric = false;
    Identityoptions.Lockout.AllowedForNewUsers = true;
    Identityoptions.Lockout.MaxFailedAccessAttempts = 5;
    Identityoptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
}).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

builder.Services.AddDbContext<Context>();
builder.Services.AddHttpClient();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

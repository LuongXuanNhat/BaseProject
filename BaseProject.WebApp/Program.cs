using BaseProject.ApiIntegration;
using BaseProject.ApiIntegration.Category;
using BaseProject.ApiIntegration.Locations;
using BaseProject.ApiIntegration.Post;
using BaseProject.ApiIntegration.RatingStars;
using BaseProject.ApiIntegration.Role;
using BaseProject.ApiIntegration.Saves;
using BaseProject.ApiIntegration.Searchs;
using BaseProject.ApiIntegration.User;
using BaseProject.Application.Common;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.System.Users;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUserApiClient, UserApiClient>();
builder.Services.AddTransient<IRoleApiClient, RoleApiClient>();
builder.Services.AddTransient<ILocationApiClient, LocationApiClient>();
builder.Services.AddTransient<IRatingApiClient, RatingApiClient>();
builder.Services.AddTransient<ICategoryApiClient, CategoryApiClient>();
builder.Services.AddTransient<ISearchApiClient, SearchApiClient>();
builder.Services.AddTransient<ISaveApiClient, SaveApiClient>();
builder.Services.AddTransient<BaseApiClient>();

builder.Services.AddMemoryCache();
builder.Services.AddTransient<ICacheService, MemoryCacheService>();

builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
 .AddCookie(options =>
 {
     options.LoginPath = "/Account/Login";
     options.LogoutPath = "/Account/Logout";
     options.AccessDeniedPath = "/User/Forbidden/";
 });
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);

});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddTransient<IUserApiClient, UserApiClient>();
builder.Services.AddTransient<IPostApiClient, PostApiClient>();
builder.Services.AddTransient<ICategoryApiClient, CategoryApiClient>();



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
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.UseRequestLocalization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

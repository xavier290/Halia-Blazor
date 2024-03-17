using Blazored.LocalStorage;
using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NovaLaundryAppWebAdminBlazor.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NovaLaundryAppWebAdminBlazor.ModelsHalia;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
// using NovaLaundryAppWebAdminBlazor.Data;
// using NovaLaundryAppWebAdminBlazor.Server.Interfaces;

string credentialPath = @"C:\Users\Usuario\source\repos\Credentials\halia-82cdf-firebase-adminsdk-ygtoo-a51e4f10e5.json";
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast(); // Registro de Blazored.Toast
builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true);

// var connectionString = builder.Configuration.GetConnectionString("Default");
// builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

// builder.Services.AddIdentity<Usuario, IdentityRole>(options => {
//     options.Password.RequiredLength = 2;
//     options.Password.RequireNonAlphanumeric = false;
//     options.Password.RequireDigit = false;
//     options.Password.RequireLowercase = false;
//     options.Password.RequireUppercase = false;
// })
// .AddEntityFrameworkStores<DataContext>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
// app.UseAuthentication();
// app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();

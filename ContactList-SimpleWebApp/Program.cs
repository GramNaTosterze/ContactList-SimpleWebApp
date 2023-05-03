using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContactList_SimpleWebApp.Data;
using ContactList_SimpleWebApp.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ContactList_SimpleWebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactList_SimpleWebAppContext") ?? throw new InvalidOperationException("Connection string 'ContactList_SimpleWebAppContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ContactList_SimpleWebAppContext>();
  
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}


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
    name: "default",
    pattern: "{controller=Contacts}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

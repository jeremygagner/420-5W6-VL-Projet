using _420_5W6_VL_Projet.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serveroptions =>
{
    serveroptions.Listen(System.Net.IPAddress.Any, 5083);
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ReeditContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.7-mariadb")).UseLazyLoadingProxies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Landing}/{action=Landing}/{id?}");

app.Run();

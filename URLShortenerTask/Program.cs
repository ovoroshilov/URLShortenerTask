using Microsoft.EntityFrameworkCore;
using URLShortenerTask.DAL;
using URLShortenerTask.DAL.Repositories;
using URLShortenerTask.Domain.Entities;
using URLShortenerTask.Domain.Models;
using URLShortenerTask.Service;
using URLShortenerTask.Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUrlShorteningService, UrlShorteningService>();
builder.Services.AddScoped<IBaseRepository<UrlEntity>, URLRepository>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<URLShortenerDbContext>(option =>
{
    option.UseSqlServer(connectionString);
});

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
    name: "default",
    pattern: "{controller=ShortUrl}/{action=CreateShortUrl}/{id?}");

app.Run();

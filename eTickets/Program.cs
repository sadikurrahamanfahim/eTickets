using eTickets.Data;
using eTickets.Data.Services;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var config = builder.Configuration;
builder.Services.AddSingleton(config);

var connectionString = config.GetConnectionString("DefaultConnectingString");
builder.Services.AddDbContext<AppDBContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IActorsService, ActorService>();
builder.Services.AddScoped<IProducersService, ProducerService>();
builder.Services.AddScoped<ICinemaService, CinemaService>();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");


//Seeding Database
AppDbInitializer.Seed(app);
app.Run();
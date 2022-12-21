using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VisioConference.Data;
using VisioConference.Main.Data;
using VisioConference.Main.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VisioConferenceMainContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VisioConferenceMainContext") ?? throw new InvalidOperationException("Connection string 'VisioConferenceMainContext' not found.")));

builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VisioConferenceDataContext") ?? throw new InvalidOperationException("Connection string 'VisioConferenceDataContext' not found.")));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

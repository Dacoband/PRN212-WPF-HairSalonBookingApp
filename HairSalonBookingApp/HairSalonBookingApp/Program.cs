using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using HairSalonBookingApp.DAO.DbInitializer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty));

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

var app = builder.Build();

// Seed the database
SeedDatabase();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}

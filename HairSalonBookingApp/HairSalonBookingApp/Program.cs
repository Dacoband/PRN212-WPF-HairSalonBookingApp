using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using HairSalonBookingApp.DAO.DbInitializer;
using HairSalonBookingApp.Repositories;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using HairSalonBookingApp.Services;
using Microsoft.EntityFrameworkCore;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using HairSalonBookingApp.BusinessObjects.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IServiceService, ServiceService>();




// Load Firebase settings from configuration
var firebaseSettings = builder.Configuration.GetSection("Firebase").Get<FirebaseSetting>();

if (firebaseSettings == null)
{
    throw new Exception("Firebase settings not found in configuration.");
}

builder.Configuration.GetSection("Firebase").Get<FirebaseSetting>();

// Combine the base path with the relative path
var credentialPath = Path.Combine(builder.Environment.ContentRootPath, firebaseSettings.CredentialPath);

// Initialize FirebaseApp and register it as a singleton service
var firebaseApp = FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile(credentialPath)
});

builder.Services.AddSingleton(firebaseApp);



builder.Services.AddDbContext<ApplicationDbContext>(
    options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty));

#region Dependency Injection

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAppointmentCancellationRepository, AppointmentCancellationRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentServiceRepository, AppointmentServiceRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IStaffManagerRepository, StaffManagerRepository>();
builder.Services.AddScoped<IStaffStylistRepository, StaffStylistRepository>();
builder.Services.AddScoped<IStylistRepository, StylistRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
#endregion
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

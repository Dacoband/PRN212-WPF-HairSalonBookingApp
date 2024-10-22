using HairSalonBookingApp.BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public ApplicationDbContext()
        {
        }
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<AppointmentCancellation> AppointmentCancellations { get; set; } = null!;
        public DbSet<AppointmentService> AppointmentServices { get; set; } = null!;
        public DbSet<Branch> Branches { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<StaffManager> StaffManagers { get; set; } = null!;
        public DbSet<StaffStylist> StaffStylists { get; set; } = null!;
        public DbSet<Stylist> Stylists { get; set; } = null!;

        private string? GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            return config.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString() ?? string.Empty);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

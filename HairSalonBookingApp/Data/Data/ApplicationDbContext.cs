using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<AppointmentCancellation> AppointmentCancellations { get; set; } = null!;
        public virtual DbSet<AppointmentService> AppointmentServices { get; set; } = null!;
        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<StaffManager> StaffManagers { get; set; } = null!;
        public virtual DbSet<StaffStylist> StaffStylists { get; set; } = null!;
        public virtual DbSet<Stylist> Stylists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=14.225.205.94;Database=HairSalonBookingSystem;User ID=sa;Password=Fpt1234567890;Trust Server Certificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_Appointments_CustomerId");

                entity.HasIndex(e => e.StylistId, "IX_Appointments_StylistId");

                entity.Property(e => e.AppointmentId).ValueGeneratedNever();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Stylist)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.StylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AppointmentCancellation>(entity =>
            {
                entity.HasKey(e => e.CancellationId);

                entity.HasIndex(e => e.AppointmentId, "IX_AppointmentCancellations_AppointmentId");

                entity.Property(e => e.CancellationId).ValueGeneratedNever();

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.AppointmentCancellations)
                    .HasForeignKey(d => d.AppointmentId);
            });

            modelBuilder.Entity<AppointmentService>(entity =>
            {
                entity.HasIndex(e => e.AppointmentId, "IX_AppointmentServices_AppointmentId");

                entity.HasIndex(e => e.ServiceId, "IX_AppointmentServices_ServiceId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.AppointmentServices)
                    .HasForeignKey(d => d.AppointmentId);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.AppointmentServices)
                    .HasForeignKey(d => d.ServiceId);
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasIndex(e => e.StaffManagerID, "IX_Branches_StaffManagerID");

                entity.Property(e => e.BranchID).ValueGeneratedNever();

                entity.HasOne(d => d.StaffManager)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.StaffManagerID);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.AccountId, "IX_Customers_AccountId");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AccountId);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackID).ValueGeneratedNever();

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CustomerID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__Custom__73BA3083");

                entity.HasOne(d => d.Stylist)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.StylistID)
                    .HasConstraintName("FK__Feedback__Stylis__74AE54BC");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasIndex(e => e.MemberId, "IX_Notifications_MemberId");

                entity.Property(e => e.NotificationId).ValueGeneratedNever();

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.MemberId);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasIndex(e => e.AppointmentId, "IX_Payments_AppointmentId");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.AppointmentId);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceID).ValueGeneratedNever();
            });

            modelBuilder.Entity<StaffManager>(entity =>
            {
                entity.HasIndex(e => e.AccountID, "IX_StaffManagers_AccountID");

                entity.Property(e => e.StaffManagerID).ValueGeneratedNever();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.StaffManagers)
                    .HasForeignKey(d => d.AccountID);
            });

            modelBuilder.Entity<StaffStylist>(entity =>
            {
                entity.HasIndex(e => e.AccountId, "IX_StaffStylists_AccountId");

                entity.HasIndex(e => e.BranchID, "IX_StaffStylists_BranchID");

                entity.Property(e => e.StaffStylistId).ValueGeneratedNever();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.StaffStylists)
                    .HasForeignKey(d => d.AccountId);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.StaffStylists)
                    .HasForeignKey(d => d.BranchID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Stylist>(entity =>
            {
                entity.HasIndex(e => e.AccountId, "IX_Stylists_AccountId");

                entity.HasIndex(e => e.BranchID, "IX_Stylists_BranchID");

                entity.HasIndex(e => e.StaffStylistId, "IX_Stylists_StaffStylistId");

                entity.Property(e => e.StylistId).ValueGeneratedNever();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Stylists)
                    .HasForeignKey(d => d.AccountId);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Stylists)
                    .HasForeignKey(d => d.BranchID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.StaffStylist)
                    .WithMany(p => p.Stylists)
                    .HasForeignKey(d => d.StaffStylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

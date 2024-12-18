﻿// <auto-generated />
using System;
using HairSalonBookingApp.DAO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HairSalonBookingApp.DAO.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountId");

                    b.Property<bool>("DelFlg")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AppointmentId");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DelFlg")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StylistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<DateTime>("UpdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StylistId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.AppointmentCancellation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CancellationId");

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DelFlg")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("AppointmentCancellations");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.AppointmentService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DelFlg")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.Property<DateTime>("UpdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("AppointmentServices");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Branch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BranchID");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DelFlg")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalonBranches")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StaffManagerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StaffManagerID");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerId");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvatarImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DelFlg")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FeedbackId");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DelFlg")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("StylistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StylistId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("NotificationId");

                    b.Property<bool>("DelFlg")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PaymentId");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DelFlg")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ServiceID");

                    b.Property<string>("AvatarImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DelFlg")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.StaffManager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("StaffManagerID");

                    b.Property<Guid>("AccountID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvatarImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BranchID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DelFlg")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffManagerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountID");

                    b.HasIndex("BranchID");

                    b.ToTable("StaffManagers");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.StaffStylist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("StaffStylistId");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvatarImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BranchID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DelFlg")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffStylistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BranchID");

                    b.ToTable("StaffStylists");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Stylist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("StylistId");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvatarImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AverageRating")
                        .HasColumnType("float");

                    b.Property<Guid>("BranchID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DelFlg")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StaffStylistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StylistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BranchID");

                    b.HasIndex("StaffStylistId");

                    b.ToTable("Stylists");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Appointment", b =>
                {
                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Stylist", "Stylist")
                        .WithMany()
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Stylist");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.AppointmentCancellation", b =>
                {
                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.AppointmentService", b =>
                {
                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Appointment", null)
                        .WithMany("AppointmentService")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Service", "Service")
                        .WithMany("AppointmentService")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Branch", b =>
                {
                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.StaffManager", "StaffManager")
                        .WithMany()
                        .HasForeignKey("StaffManagerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffManager");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Customer", b =>
                {
                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Feedback", b =>
                {
                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.StaffStylist", "StaffStylist")
                        .WithMany()
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("StaffStylist");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Notification", b =>
                {
                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Customer", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Payment", b =>
                {
                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.StaffManager", b =>
                {
                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID");

                    b.Navigation("Account");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.StaffStylist", b =>
                {
                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Stylist", b =>
                {
                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HairSalonBookingApp.BusinessObjects.Entities.StaffStylist", "StaffStylist")
                        .WithMany()
                        .HasForeignKey("StaffStylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Branch");

                    b.Navigation("StaffStylist");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Appointment", b =>
                {
                    b.Navigation("AppointmentService");
                });

            modelBuilder.Entity("HairSalonBookingApp.BusinessObjects.Entities.Service", b =>
                {
                    b.Navigation("AppointmentService");
                });
#pragma warning restore 612, 618
        }
    }
}

using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.BusinessObjects.Enum;
using HairSalonBookingApp.DAO.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DbInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            if (_dbContext.Database.GetPendingMigrations().Count() > 0)
            {
                _dbContext.Database.Migrate();
            };
            SeedUser();
            SeedStaffManagers();
            SeedBranches();
        }

        private void SeedUser()
        {
            // Check if an admin user already exists
            var adminUser = _dbContext.Accounts.FirstOrDefault(user => user.RoleName == RoleEnum.Admin.ToString());
            if (adminUser == null)
            {
                // If no admin user exists, create one
                var newAdminUser = new Account
                {
                    Email = "admin@example.com",
                    // Hash the password for security
                    Password = BCrypt.Net.BCrypt.HashPassword("12345678"),
                    RoleName = RoleEnum.Admin.ToString(),
                };

                _dbContext.Accounts.Add(newAdminUser);

                //create a list of staff managers
                var SMUsers = new List<Account>
                {
                    new Account()
                    {
                        Id = Guid.Parse("26e358ec-d5c5-484a-bc9f-2ea79a55ffa9"),
                        Email = "JohnDoe@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("12345"),
                        RoleName = RoleEnum.StaffManager.ToString()
                    },
                    new Account()
                    {
                        Id = Guid.Parse("b13f2183-cd7d-401a-971a-2e5e2a1ce99d"),
                        Email = "JaneSmith@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("12345"),
                        RoleName = RoleEnum.StaffManager.ToString()
                    }
                };
                _dbContext.Accounts.AddRange(SMUsers);

                _dbContext.SaveChanges();
            }
        }

        private void SeedStaffManagers()
        {
            if (_dbContext.StaffManagers.Any())
            {
                // Data already seeded
                return;
            }
            var staffManagers = new List<StaffManager>
            {
                new StaffManager
                {
                    Id = Guid.Parse("e3a1b4b2-4d4b-4b8b-9c1c-0d2a5d6f7e8a"),
                    AccountID = Guid.Parse("26e358ec-d5c5-484a-bc9f-2ea79a55ffa9"),
                    StaffManagerName = "John Doe",
                    DateOfBirth = new DateTime(1985, 7, 19),
                    PhoneNumber = "123-456-7890",
                    Address = "123 Main Street, Anytown",
                    AvatarImage = "john_doe_avatar.jpg"
                },
                new StaffManager
                {
                    Id = Guid.Parse("ee6b71d7-b5bc-4111-a429-ce2338b56974"),
                    AccountID = Guid.Parse("b13f2183-cd7d-401a-971a-2e5e2a1ce99d"),
                    StaffManagerName = "Jane Smith",
                    DateOfBirth = new DateTime(1990, 5, 23),
                    PhoneNumber = "987-654-3210",
                    Address = "456 Elm Street, Othertown",
                    AvatarImage = "jane_smith_avatar.jpg"
                }
                // Add more entries based on your JSON data
            };

            _dbContext.StaffManagers.AddRange(staffManagers);
            _dbContext.SaveChanges();
        }

        private void SeedBranches()
        {
            // Check if branches already exist
            if (_dbContext.Branches.Count() == 0)
            {
                // If no branches exist, create some
                var branches = new List<Branch>
                {
                    new Branch
                    {
                        Id = Guid.Parse("c8f0c5e0-4ebb-4659-acef-de4a599e36c5"),
                        StaffManagerID = Guid.Parse("e3a1b4b2-4d4b-4b8b-9c1c-0d2a5d6f7e8a"),
                        SalonBranches = "Chi Nhánh 2",
                        Address = "861/18/19A5,Trần Xuân Soạn,Phường Tân Hưng, Quận 7, Thành phố Hồ Chí Minh",
                        Phone = "0908767976",
                        InsDate = DateTime.Parse("2024-10-16T11:54:22.343Z"),
                        UpdDate = DateTime.Parse("2024-11-09T03:52:48.282Z"),
                        DelFlg = false
                    },
                    new Branch
                    {
                        Id = Guid.Parse("d69b504c-d169-4eeb-83fa-08f32be97b1b"),
                        StaffManagerID = Guid.Parse("ee6b71d7-b5bc-4111-a429-ce2338b56974"),
                        SalonBranches = "Chi Nhánh 1",
                        Address = "12 Tôn Thất Đạm, phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh",
                        Phone = "09111123678",
                        InsDate = DateTime.Parse("2024-10-16T11:54:44.465Z"),
                        UpdDate = DateTime.Parse("2024-11-07T06:17:53.124Z"),
                        DelFlg = false
                    }
                };

                _dbContext.Branches.AddRange(branches);
                _dbContext.SaveChanges();
            }
        }
    }
}

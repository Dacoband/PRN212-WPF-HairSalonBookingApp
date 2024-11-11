using FirebaseAdmin.Messaging;
using HairSalonBookingApp.BusinessObjects.DTOs.StaffManager;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.BusinessObjects.Enum;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services
{
    public class StaffManagerService : IStaffManagerService
    {
        private readonly IStaffManagerRepository _staffManagerRepository;
        private readonly IFirebaseService _firebaseService;
        private readonly IAccountRepository _accountRepository;

        public StaffManagerService(IStaffManagerRepository staffManagerRepository, IFirebaseService firebaseService, IAccountRepository accountRepository)
        {
            _staffManagerRepository = staffManagerRepository;
            _firebaseService = firebaseService;
            _accountRepository = accountRepository;
        }

        public async Task<bool> CreateStaffManager(CreateStaffManagerRequest createStaffManagerRequest)
        {
            try
            {
                var account = new Account
                {
                    Id = Guid.NewGuid(),
                    Email = createStaffManagerRequest.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(createStaffManagerRequest.Password),
                    RoleName = RoleEnum.StaffManager.ToString(),
                };
                await _accountRepository.AddAsync(account);
                var url = await _firebaseService.UploadFile(createStaffManagerRequest.AvatarImage);
                var staffManager = new StaffManager
                {
                    Id = Guid.NewGuid(),
                    AccountID = account.Id,
                    BranchID = createStaffManagerRequest.BranchID,
                    StaffManagerName = createStaffManagerRequest.StaffManagerName,
                    DateOfBirth = createStaffManagerRequest.DateOfBirth,
                    PhoneNumber = createStaffManagerRequest.PhoneNumber,
                    Address = createStaffManagerRequest.Address,
                    AvatarImage = url
                };
                await _staffManagerRepository.AddAsync(staffManager);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteStaffManager(Guid managerId)
        {
            try
            {
                var staffManager = await _staffManagerRepository.GetAsync(managerId);
                if (staffManager == null)
                {
                    return false;
                }
                staffManager.DelFlg = true;
                _staffManagerRepository.Update(staffManager);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public async Task<List<StaffManager>> GetAllStaffManager()
        {
            var staffManagers = await _staffManagerRepository.GetAllAsync(includeProperties: "Account");
            return staffManagers.ToList();
        }

        public async Task<StaffManager?> GetStaffManagerById(Guid managerId)
        {
            var staffManager = await _staffManagerRepository.GetAsync(managerId);
            if (staffManager == null) 
            {
                return null;
            }
            return staffManager;
        }

        public async Task<(bool, string)> UpdateStaffManager(UpdateStaffManagerRequest updateStaffManagerRequest)
        {
            string message;
            try
            {
                var staffManager = await _staffManagerRepository.GetAsync(updateStaffManagerRequest.Id);
                if (staffManager == null)
                {
                    message = "Staff Manager not found";
                    return (false, message);
                }

                var url = "";
                if (updateStaffManagerRequest.AvatarImage != null)
                {
                    url = await _firebaseService.UploadFile(updateStaffManagerRequest.AvatarImage);
                }

                staffManager.BranchID = updateStaffManagerRequest.BranchID ?? staffManager.BranchID;
                staffManager.StaffManagerName = updateStaffManagerRequest.StaffManagerName ?? staffManager.StaffManagerName;
                staffManager.DateOfBirth = updateStaffManagerRequest.DateOfBirth;
                staffManager.PhoneNumber = updateStaffManagerRequest.PhoneNumber ?? staffManager.PhoneNumber;
                staffManager.Address = updateStaffManagerRequest.Address ?? staffManager.Address;
                staffManager.AvatarImage = updateStaffManagerRequest.AvatarImage != null ? url : staffManager.AvatarImage;

                if (_staffManagerRepository.Update(staffManager))
                {
                    message = "Staff Manager updated successfully";
                    return (true, message);
                }
                message = "Staff Manager updated failed";
                return (false, message);
            }
            catch(Exception ex)
            {
                message = ex.Message;
                return (false, message);
            }
        }
    }
}

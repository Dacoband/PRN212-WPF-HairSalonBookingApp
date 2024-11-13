using HairSalonBookingApp.BusinessObjects.DTOs.StaffStylist;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.BusinessObjects.Enum;
using HairSalonBookingApp.Repositories;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services
{
    public class StaffStylistService : IStaffStylistService
    {
        private readonly IStaffStylistRepository _staffStylistRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IFirebaseService _firebaseService; 

        public StaffStylistService(IStaffStylistRepository staffStylistRepository, IFirebaseService firebaseService, IAccountRepository accountRepository, IBranchRepository branchRepository)
        {
            _staffStylistRepository = staffStylistRepository;
            _firebaseService = firebaseService;
            _accountRepository = accountRepository;
            _branchRepository = branchRepository;
        }

        public async Task<bool> CreateStaffStylist(CreateStaffStylistRequest createStaffStylistRequest)
        {
            string message;
            try
            {
                var account = new Account
                {
                    Email = createStaffStylistRequest.Email,
                    Password = createStaffStylistRequest.Password,
                    RoleName = RoleEnum.StaffStylist.ToString()
                };
                await _accountRepository.AddAsync(account);
                var url = await _firebaseService.UploadFile(createStaffStylistRequest.AvatarImage);
                var branch = await _branchRepository.GetAsync(createStaffStylistRequest.BranchID);
                if (branch == null)
                {
                    message = "Branch not found";
                    return false;
                }
                var staffStylist = new StaffStylist
                {
                    AccountId = account.Id,
                    BranchID = createStaffStylistRequest.BranchID,
                    StaffStylistName = createStaffStylistRequest.StaffStylistName,
                    DateOfBirth = createStaffStylistRequest.DateOfBirth,
                    PhoneNumber = createStaffStylistRequest.PhoneNumber,
                    Address = createStaffStylistRequest.Address,
                    AvatarImage = url
                };
                await _staffStylistRepository.AddAsync(staffStylist);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                message = ex.Message;
                return false;
            }
            message = "Staff Stylist created successfully";
            return true;
        }

        public async Task<bool> DeleteStaffStylist(Guid staffId)
        {
            string message;
            try
            {
                var staffStylist = await _staffStylistRepository.GetAsync(staffId);
                if (staffStylist == null)
                {
                    message = "StaffStylist not found";
                    return false;
                }
                staffStylist.DelFlg = true;
                _staffStylistRepository.Update(staffStylist);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                message = ex.Message;
                return false;
            }
            return true;
        }

        public async Task<StaffStylist?> GetStaffStylistById(Guid staffId)
        {
            var staffStylist = await _staffStylistRepository.GetAsync(staffId);
            if(staffStylist == null)
            {
                return null;
            }
            return staffStylist;
        }

        public async Task<List<StaffStylist>> GetStaffStylists()
        {
            var staffStylists = await _staffStylistRepository.GetAllAsync(includeProperties:"Account,Branch");
            return staffStylists.ToList();
        }

        public async Task<(bool,string)> UpdateStaffStylist(UpdateStaffStylistRequest updateStaffStylistRequest)
        {
            string message;
            try
            {
                var staffStylist = await _staffStylistRepository.GetAsync(updateStaffStylistRequest.Id);
                if (staffStylist == null)
                {
                    message = "StaffStylist not found";
                    return (false, message);
                }
                var branch = await _branchRepository.GetAsync(updateStaffStylistRequest.BranchID ?? default);
                if (branch == null)
                {
                    message = "Branch not found";
                    return (false, message);
                }
                var url = "";
                if (updateStaffStylistRequest.AvatarImage != null)
                {
                    url = await _firebaseService.UploadFile(updateStaffStylistRequest.AvatarImage);
                }
                staffStylist.BranchID = updateStaffStylistRequest.BranchID ?? staffStylist.BranchID;
                staffStylist.StaffStylistName = updateStaffStylistRequest.StaffStylistName ?? staffStylist.StaffStylistName;
                staffStylist.DateOfBirth = updateStaffStylistRequest.DateOfBirth ?? staffStylist.DateOfBirth;
                staffStylist.PhoneNumber = updateStaffStylistRequest.PhoneNumber ?? staffStylist.PhoneNumber;
                staffStylist.Address = updateStaffStylistRequest.Address ?? staffStylist.Address;
                staffStylist.AvatarImage = url ?? staffStylist.AvatarImage;
                if (_staffStylistRepository.Update(staffStylist))
                {
                    message = "Staff Stylist updated successfully";
                    return (true, message);
                }
                message = "Staff Stylist updated failed";
                return (false, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                message = ex.Message;
                return (false, message);
            }
        }
    }
}

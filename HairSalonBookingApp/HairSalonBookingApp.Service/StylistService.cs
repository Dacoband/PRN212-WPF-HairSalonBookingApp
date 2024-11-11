using HairSalonBookingApp.BusinessObjects.DTOs.StaffManager;
using HairSalonBookingApp.BusinessObjects.DTOs.Stylist;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.BusinessObjects.Enum;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services
{
    public class StylistService : IStylistService
    {
        private readonly IStylistRepository _stylistRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IFirebaseService _firebaseService;
        private readonly IStaffStylistRepository _staffStylistRepository;

        public StylistService(IStylistRepository stylistRepository, IAccountRepository accountRepository, IBranchRepository branchRepository, IFirebaseService firebaseService, IStaffStylistRepository staffStylistRepository)
        {
            _stylistRepository = stylistRepository;
            _accountRepository = accountRepository;
            _branchRepository = branchRepository;
            _firebaseService = firebaseService;
            _staffStylistRepository = staffStylistRepository;
        }

        public async Task<bool> CreateStylist(CreateStylistRequest createStylistRequest)
        {
            try
            {
                var account = new Account
                {
                    Id = Guid.NewGuid(),
                    Email = createStylistRequest.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(createStylistRequest.Password),
                    RoleName = RoleEnum.Stylist.ToString(),
                };
                await _accountRepository.AddAsync(account);
                var url = await _firebaseService.UploadFile(createStylistRequest.AvatarImage);
                var branch = await _branchRepository.GetAsync(createStylistRequest.BranchID);
                if (branch == null)
                {
                    return false;
                }
                var staffStylist = await _staffStylistRepository.GetAsync(createStylistRequest.StaffStylistId);
                if (staffStylist == null)
                {
                    return false;
                }
                var stylist = new Stylist
                {
                    Id = Guid.NewGuid(),
                    AccountId = account.Id,
                    BranchID = createStylistRequest.BranchID,                  
                    StaffStylistId = createStylistRequest.StaffStylistId,
                    StylistName = createStylistRequest.StylistName,
                    PhoneNumber = createStylistRequest.PhoneNumber,
                    Address = createStylistRequest.Address,
                    AvatarImage = url
                };
                await _stylistRepository.AddAsync(stylist);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteStylist(Guid stylistId)
        {
            try
            {
                var stylist = await _stylistRepository.GetAsync(stylistId);
                if (stylist == null)
                {
                    return false;
                }
                stylist.DelFlg = true;
                _stylistRepository.Update(stylist);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public async Task<List<Stylist>> GetAllStylists()
        {
            var stylists = await _stylistRepository.GetAllAsync(includeProperties:"Account,Branch,StaffStylist");
            return stylists.ToList();
        }

        public async Task<Stylist?> GetStylistById(Guid stylistId)
        {
            var stylist = await _stylistRepository.GetAsync(stylistId);
            if (stylist == null)
            {
                return null;
            }
            return stylist;
        }

        public async Task<(bool, string)> UpdateStylist(UpdateStylistRequest updateStylistRequest)
        {
            string message;
            try
            {
                var stylist = await _stylistRepository.GetAsync(updateStylistRequest.Id);
                if(stylist == null)
                {
                    message = "Stylist not found";
                    return (false, message);
                }
                var branch = await _branchRepository.GetAsync(updateStylistRequest.BranchID ?? default);
                if (branch == null)
                {
                    message = "Branch not found";
                    return (false, message);
                }
                var staffStylist = await _staffStylistRepository.GetAsync(updateStylistRequest.StaffStylistId ?? default);
                if (staffStylist == null)
                {
                    message = "Staff Stylist not found";
                    return (false, message);
                }
                var url = "";
                if (updateStylistRequest.AvatarImage != null)
                {
                    url = await _firebaseService.UploadFile(updateStylistRequest.AvatarImage);
                }
                stylist.StylistName = updateStylistRequest.StylistName ?? stylist.StylistName;
                stylist.StaffStylistId = updateStylistRequest.StaffStylistId ?? stylist.StaffStylistId;
                stylist.BranchID = updateStylistRequest.BranchID ?? stylist.BranchID;
                stylist.PhoneNumber = updateStylistRequest.PhoneNumber ?? stylist.PhoneNumber;
                stylist.Address = updateStylistRequest.Address ?? stylist.Address;
                stylist.AvatarImage = updateStylistRequest.AvatarImage != null ? url : stylist.AvatarImage; 
                if (_stylistRepository.Update(stylist))
                {
                    message = "Update stylist successfully";
                    return (true, message);
                }
                else
                {
                    message = "Update stylist failed";
                    return (false, message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (false, ex.Message);
            }
        }
    }
}

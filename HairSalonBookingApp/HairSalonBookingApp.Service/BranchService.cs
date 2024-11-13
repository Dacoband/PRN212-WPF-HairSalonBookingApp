using FirebaseAdmin.Messaging;
using HairSalonBookingApp.BusinessObjects.DTOs.Branch;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IStaffManagerRepository _staffManagerRepository;
        public BranchService(IBranchRepository branchRepository, IStaffManagerRepository staffManagerRepository)
        {
            _branchRepository = branchRepository;
            _staffManagerRepository = staffManagerRepository;
        }

        [Authorize(Roles = "Admin")]
        public async Task<bool> AddBranch(CreateBracnhRequest createBracnh)
        {
            try
            {
                var staffManger = await _staffManagerRepository.GetAsync(createBracnh.StaffManagerID);
                if (staffManger == null)
                {
                    return false;
                }

                var branch = new Branch
                {
                    Id = Guid.NewGuid(),
                    StaffManagerID = createBracnh.StaffManagerID,
                    SalonBranches = createBracnh.SalonBranches,
                    Address = createBracnh.Address,
                    Phone = createBracnh.Phone

                };
                await _branchRepository.AddAsync(branch);
                staffManger.BranchID = branch.Id;
                _staffManagerRepository.Update(staffManger);

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteBranch(Guid branchId)
        {
            try
            {
                var branch = await _branchRepository.GetAsync(branchId);
                if (branch == null)
                {
                    return false;
                }
                branch.DelFlg = true;
                _branchRepository.Update(branch);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public async Task<List<Branch>> GetAllBranches()
        {
            var branches = await _branchRepository.GetAllAsync(includeProperties:"StaffManager");
            return branches.ToList();
        }

        public async Task<List<Branch>> GetAllBranchNotStaffManager()
        {
            var branches = await _branchRepository.GetAllAsync(includeProperties: "StaffManager");
            return branches.Where(x => x.StaffManagerID == null).ToList();
        }

        public async Task<Branch?> GetBranchById(Guid branch)
        {
            var branchs = await _branchRepository.GetAsync(branch);
            if (branchs == null)
            {
                return null;
            }
            return branchs;

        }

        public Task<Branch?> GetBranchesByStaffManager(Guid staffManagerId)
        {
            var staffManager = _staffManagerRepository.GetAsync(staffManagerId);
            if (staffManager == null)
            {
                return null;
            }
            var branch = _branchRepository.GetBranchByStaffManagerID(staffManagerId);
            return branch;
        }

        public async Task<(bool, string)> UpdateBranch(Guid branchId, UpdateBranchRequest updateBranchRequest)
        {
            string message;
            try
            {
                var branch = await _branchRepository.GetAsync(branchId);
                if (branch == null)
                {
                    message = "Branch not found";
                    return (false, message);
                }

                var staffManager = await _staffManagerRepository.GetAsync(updateBranchRequest.StaffManagerID ?? default);
                if (staffManager == null)
                {
                    message = "Staff Manager not found";
                    return (false, message);
                }

                if (staffManager.BranchID != null)
                {
                    message = "Staff Manager was assigned to other branch";
                    return (false, message);
                }

                branch.StaffManagerID = updateBranchRequest.StaffManagerID ?? branch.StaffManagerID;
                branch.SalonBranches = updateBranchRequest.SalonBranches ?? branch.SalonBranches;
                branch.Address = updateBranchRequest.Address ?? branch.Address;
                branch.Phone = updateBranchRequest.Phone ?? branch.Phone;

                if (_branchRepository.Update(branch))
                {
                    message = "Branch updated successfully";
                    return (true, message);
                }
                message = "Branch update failed";
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

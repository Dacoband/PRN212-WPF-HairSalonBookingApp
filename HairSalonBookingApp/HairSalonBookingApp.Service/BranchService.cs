using HairSalonBookingApp.BusinessObjects.DTOs.Branch;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Service
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
        public async Task<ActionResult> AddBranch(CreateBracnhRequest createBracnh, HttpContext httpContext)
        {
            var staffManger = await _staffManagerRepository.GetAsync(createBracnh.StaffManagerID);
            if (staffManger == null)
            {
                return new BadRequestObjectResult("Staff Manager not found")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
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


            return new OkObjectResult("Branch created successfully");
        }

        public async Task<bool> DeleteBranch(Guid branchId)
        {
            var branch = await _branchRepository.GetAsync(branchId);
            if (branch == null)
            {
                return false;
            }
            branch.DelFlg = true;
            _branchRepository.Update(branch);
            return true;
        }

        public async Task<ActionResult<List<Branch>>> GetAllBranches()
        {
            var branches = await _branchRepository.GetAllAsync();
            return new OkObjectResult(branches);
        }

        public async Task<ActionResult<Branch>> GetBranchById(Guid branch)
        {
            var branchs = await _branchRepository.GetAsync(branch);
            if (branchs == null)
            {
                return new NotFoundObjectResult("Branch not found")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            return new OkObjectResult(branch);

        }

        public Task<List<Branch>> GetBranchesByStaffManager(Guid staffManagerId)
        {
            var branches = _branchRepository.GetBranchByStaffManagerID(staffManagerId);
            return branches;
        }

        public async Task<(bool, string)> UpdateBranch(Guid branchId, UpdateBranchRequest updateBranchRequest)
        {
            string message;
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
            
            if(staffManager.BranchID != null)
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
    }
}

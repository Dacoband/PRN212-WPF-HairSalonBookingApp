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
        public async Task<ActionResult> AddBranch(CreateBracnhRequest createBracnh, HttpContext httpContext)
        {
            //var branch = new Branch
            //{
            //    BranchID = Guid.NewGuid(),
            //    StaffManagerID = createBracnh.StaffManagerID,
            //    SalonBranches = createBracnh.SalonBranches,
            //    Address = createBracnh.Address,
            //    Phone = createBracnh.Phone
                
            //};
           
            //var result = await _branchRepository.Add(branch);

            //if (result == null)
            //{
            //    return new BadRequestObjectResult("Branch not created");
            //}

            return new OkObjectResult("Branch created successfully");
        }

        public Task<bool> DeleteBranch(Guid branchId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<Branch>>> GetAllBranches()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Branch>> GetBranchById(Guid branch)
        {
            throw new NotImplementedException();
        }

        public Task<List<Branch>> GetBranchesByStaffManager(Guid staffManagerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBranch(Guid branchId, UpdateBranchRequest updateBranchRequest)
        {
            throw new NotImplementedException();
        }
    }
}

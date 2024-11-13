using HairSalonBookingApp.BusinessObjects.DTOs.Branch;
using HairSalonBookingApp.BusinessObjects.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services.Interface
{
    public interface IBranchService
    {
        Task<bool> AddBranch(CreateBracnhRequest createBracnh);
        Task<(bool, string)> UpdateBranch(Guid branchId, UpdateBranchRequest updateBranchRequest);
        Task<bool> DeleteBranch(Guid branchId);
        Task<List<Branch>> GetAllBranches();
        Task<Branch?> GetBranchById(Guid branch);
        Task<Branch?> GetBranchesByStaffManager(Guid staffManagerId);
        Task<List<Branch>> GetAllBranchNotStaffManager();   
    }
}

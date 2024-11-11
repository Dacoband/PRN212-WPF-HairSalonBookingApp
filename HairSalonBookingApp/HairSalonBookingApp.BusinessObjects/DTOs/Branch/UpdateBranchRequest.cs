using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.DTOs.Branch
{
    public class UpdateBranchRequest
    {
        public Guid? StaffManagerID { get; set; }
        public string? SalonBranches { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}

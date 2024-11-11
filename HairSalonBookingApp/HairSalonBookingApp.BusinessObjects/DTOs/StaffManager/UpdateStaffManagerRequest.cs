using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.DTOs.StaffManager
{
    public class UpdateStaffManagerRequest
    {
        public Guid? BranchID { get; set; }
        public string? StaffManagerName { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; } 
        public string? Address { get; set; }
        public string? AvatarImage { get; set; }
    }
}

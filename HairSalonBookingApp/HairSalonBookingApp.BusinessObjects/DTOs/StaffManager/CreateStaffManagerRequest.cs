using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.DTOs.StaffManager
{
    public class CreateStaffManagerRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public Guid? BranchID { get; set; }
        //FK from Account
        public Guid AccountID { get; set; }
        public string? StaffManagerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; } 
        public IFormFile? AvatarImage { get; set; }
    }
}

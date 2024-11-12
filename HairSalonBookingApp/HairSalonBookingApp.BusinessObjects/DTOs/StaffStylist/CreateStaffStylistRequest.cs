using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.DTOs.StaffStylist
{
    public class CreateStaffStylistRequest
    {
        [Required(ErrorMessage = "BranchId is required.")]
        public Guid BranchID { get; set; }

        [Required(ErrorMessage = "Email is missing")]
        [EmailAddress] // Ensure valid email format
        public string Email { get; set; }

        [Required] 
        public string Password { get; set; }

        [Required(ErrorMessage = "StaffStylistName is required.")]
        public string StaffStylistName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string PhoneNumber { get; set; }

        public string? Address { get; set; }

        public IFormFile? AvatarImage { get; set; }
    }
}

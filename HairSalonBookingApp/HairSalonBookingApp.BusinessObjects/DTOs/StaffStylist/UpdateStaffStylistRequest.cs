using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.DTOs.StaffStylist
{
    public class UpdateStaffStylistRequest
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "BranchId is required.")]
        public Guid? BranchID { get; set; }

        [EmailAddress] 
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? StaffStylistName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public IFormFile? AvatarImage { get; set; }
    }
}

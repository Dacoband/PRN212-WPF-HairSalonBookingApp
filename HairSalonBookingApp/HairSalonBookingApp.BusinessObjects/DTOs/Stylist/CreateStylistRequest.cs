using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.DTOs.Stylist
{
    public class CreateStylistRequest
    {
        [EmailAddress]
        [Required(ErrorMessage ="Vui lòng nhập Email")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public Guid BranchID { get; set; }
        public Guid StaffStylistId { get; set; }
        [Required]
        public string StylistName { get; set; }
        public double AverageRating { get; set; } = 0;
        [Required]
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public IFormFile? AvatarImage { get; set; }
    }
}

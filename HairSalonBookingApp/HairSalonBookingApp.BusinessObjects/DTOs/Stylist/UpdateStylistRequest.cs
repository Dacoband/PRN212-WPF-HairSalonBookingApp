using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.DTOs.Stylist
{
    public class UpdateStylistRequest
    {
        public Guid Id { get; set; }
        public string? StylistName { get; set; }
        public Guid? StaffStylistId { get; set; }
        public Guid? BranchID { get; set; }
        public string? Email { get; set; }  
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public IFormFile? AvatarImage { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.DTOs.Service
{
    public class UpdateNewServiceRequest
    {
        public string? ServiceName { get; set; }
        [Range(1, 3, ErrorMessage = "Dịch vụ phải thuộc kiểu 1, 2 hoặc 3")]
        public float? Price { get; set; }
        public string? Description { get; set; }

        [Range(10, 480, ErrorMessage = "Thời gian thực hiện dịch vụ phải trong khoảng 10 - 480 phút")]
        public int? Duration { get; set; }

        public IFormFile? AvatarImage { get; set; }

        public DateTime? UpdDate = DateTime.Now;
    }
}

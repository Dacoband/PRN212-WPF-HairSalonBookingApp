using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace HairSalonBookingApp.BusinessObjects.DTOs.Service
{
    public class CreateNewServiceRequest
    {
        [Required(ErrorMessage = "Bạn phải nhập tên dịch vụ")]
        [StringLength(100, ErrorMessage = "Tên dịch vụ không được quá 100 ký tự")]
        public string ServiceName { get; set; }

        [RegularExpression(@"^[+-]?[0-9]+$", ErrorMessage = "Hãy nhập số nguyên.")]
        [Range(1001, int.MaxValue, ErrorMessage = "Giá dịch vụ phải lớn hơn 1000.")]
        [Required(ErrorMessage = "Bạn phải nhập giá dịch vụ")]
        public int Price { get; set; }

        public string? Description { get; set; }

        [RegularExpression(@"^[+-]?[0-9]+$", ErrorMessage = "Hãy nhập số nguyên.")]
        [Required(ErrorMessage = "Bạn phải nhập thời gian thực hiện dịch vụ")]
        [Range(10, 480, ErrorMessage = "Thời gian thực hiện dịch vụ phải trong khoảng 10 - 480 phút")]
        public int Duration { get; set; } // minutes

        [Required(ErrorMessage = "Bạn phải chọn ảnh dịch vụ")]
        public IFormFile AvatarImage { get; set; }
    }
}

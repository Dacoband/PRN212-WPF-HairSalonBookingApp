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

        [RegularExpression(@"^[1-9]\d*(\.\d+)?$", ErrorMessage = "Giá dịch vụ phải lớn hơn 0")]
        //1 thuong - 2 combo
        [Required(ErrorMessage = "Bạn phải nhập giá dịch vụ")]
        public float Price { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập thời gian thực hiện dịch vụ")]
        [Range(10, 480, ErrorMessage = "Thời gian thực hiện dịch vụ phải trong khoảng 10 - 480 phút")]
        public int Duration { get; set; } // minutes

        [Required(ErrorMessage = "Bạn phải chọn ảnh dịch vụ")]
        public IFormFile AvatarImage { get; set; }
    }
}

using HairSalonBookingApp.BusinessObjects.DTOs.Service;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalonBookingApp.BusinessObjects.Entities;

namespace HairSalonBookingApp.Pages.ServicePage
{
    public class EditModel : PageModel
    {
        private readonly IServiceService _serviceService;
        private readonly IFirebaseService _firebaseService;

        public EditModel(IServiceService serviceService, IFirebaseService firebaseService)
        {
            _serviceService = serviceService;
            _firebaseService = firebaseService;
        }
        [BindProperty]
        public UpdateNewServiceRequest Service { get; set; }

        public Guid ServiceId { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid serviceId)
        {
            ServiceId = serviceId;
            var service = await _serviceService.GetServiceById(serviceId);

            if (service.Value == null)
            {
                return NotFound();
            }

            Service = new UpdateNewServiceRequest
            {
                ServiceName = service.Value.ServiceName,
                Price = service.Value.Price,
                Description = service.Value.Description,
                Duration = service.Value.Duration,
                AvatarImage = null // Không hiển thị ảnh khi update, chỉ tải lên mới
            };

            return Page();
        }



        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Thực hiện cập nhật dịch vụ
            var result = await _serviceService.UpdateService(ServiceId, Service);
            if (result)
            {
                TempData["SuccessMessage"] = "Cập nhật dịch vụ thành công!";
                return RedirectToPage("/Services/ServiceList");
            }

            TempData["ErrorMessage"] = "Cập nhật dịch vụ thất bại!";
            return Page();
        }
    }
    }

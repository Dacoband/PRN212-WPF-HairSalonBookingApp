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
        public UpdateNewServiceRequest Service { get; set; } = new UpdateNewServiceRequest();

        public Guid ServiceId { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            ServiceId = Guid.Parse(id);  
            var service = await _serviceService.GetServiceById(ServiceId);

            if (service == null)
            {
                TempData["error"] = "Không tìm thấy dịch vụ!";
                return RedirectToPage("/Services/ServiceList");
            }

            Service.Duration = service.Duration;
            Service.ServiceName = service.ServiceName;
            Service.Price = service.Price;
            Service.Description = service.Description;
            Service.AvatarImage = null;

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

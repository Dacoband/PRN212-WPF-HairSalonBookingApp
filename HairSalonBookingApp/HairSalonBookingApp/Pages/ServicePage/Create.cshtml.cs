using HairSalonBookingApp.BusinessObjects.DTOs.Service;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.ServicePage
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IServiceService _serviceService;

        [BindProperty]
        public CreateNewServiceRequest ServiceModel { get; set; } = null!;

        public CreateModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var result = await _serviceService.AddService(ServiceModel);
            if (result)
            {
                return RedirectToPage("List");
            }

            TempData["error"] = "Error creating service.";
            return Page();
        }
        
    }
}

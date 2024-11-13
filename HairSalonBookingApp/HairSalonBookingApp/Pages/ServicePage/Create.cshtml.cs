using HairSalonBookingApp.BusinessObjects.DTOs.Service;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.ServicePage
{
    public class CreateModel : PageModel
    {
        private readonly IServiceService _serviceService;

        [BindProperty]
        public CreateNewServiceRequest ServiceModel { get; set; }

        public CreateModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
           

            var result = await _serviceService.AddService(ServiceModel);
            if (result)
            {
                TempData["success"] = "Service created successfully.";
                return RedirectToPage("List");
            }

            ModelState.AddModelError(string.Empty, "Error creating service.");

            return RedirectToPage("List");
        }
        
    }
}

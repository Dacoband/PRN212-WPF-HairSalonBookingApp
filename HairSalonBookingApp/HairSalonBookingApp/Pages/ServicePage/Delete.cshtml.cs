using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalonBookingApp.BusinessObjects.Entities;

namespace HairSalonBookingApp.Pages.ServicePage
{
    public class DeleteModel : PageModel
    {
        private readonly IServiceService _serviceService;
        public DeleteModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [BindProperty]
        public Service serviceModel { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var service = await _serviceService.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            else
            {
                serviceModel = service;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            try
            {
                var service = await _serviceService.GetServiceById(id);
                if (service == null)
                {
                    TempData["error"] = "Service not found";
                    return Page();
                }
                await _serviceService.DeleteService(service);
                return RedirectToPage("List");
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
            return Page();
        }
    }
}

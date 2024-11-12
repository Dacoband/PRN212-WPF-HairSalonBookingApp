using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalonBookingApp.BusinessObjects.Entities;

namespace HairSalonBookingApp.Pages.ServicePage
{
    public class DetailsModel : PageModel
    {
        private readonly IServiceService _serviceService;
        public DetailsModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public Service serviceModel { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var service= await _serviceService.GetServiceById(id);
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
    }
}

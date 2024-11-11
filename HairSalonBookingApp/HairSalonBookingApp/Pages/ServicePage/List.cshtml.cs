using HairSalonBookingApp.BusinessObjects.DTOs.Service;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalonBookingApp.BusinessObjects.Entities;

namespace HairSalonBookingApp.Pages.ServicePage
{
    public class ListModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public List<Service> Services { get; set; }

        public ListModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task OnGetAsync()
        {
            var result = await _serviceService.GetServiceList(new QueryService());
            if (result.Result is OkObjectResult okResult)
            {
                Services = okResult.Value as List<Service>;
            }
            else
            {
                Services = new List<Service>();
            }
        }
    }
}

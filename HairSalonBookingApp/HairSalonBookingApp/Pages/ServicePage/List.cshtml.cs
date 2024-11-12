using HairSalonBookingApp.BusinessObjects.DTOs.Service;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalonBookingApp.BusinessObjects.Entities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using HairSalonBookingApp.Helper;

namespace HairSalonBookingApp.Pages.ServicePage
{
    public class ListModel : PageModel
    {
        private readonly IServiceService _serviceService;

        [BindProperty]
        public List<Service> Services { get; set; } = new List<Service>();
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IServiceService serviceService, IHttpContextAccessor httpContextAccessor)
        {
            _serviceService = serviceService;
        }

        public async Task OnGet()
        {
           
            var result = await _serviceService.GetServiceList(new QueryService());
            if (result.Result is OkObjectResult okResult)
            {
                var allServices = okResult.Value as List<Service>;

                // Kiểm tra SearchTerm và lọc danh sách dịch vụ
                if (!string.IsNullOrEmpty(SearchTerm))
                {
                    Services = allServices
                        .Where(s => s.ServiceName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                                    s.Description.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }
                else
                {
                    Services = allServices;
                }
            }
            else
            {
                Services = new List<Service>();
            }
        }

    }
}

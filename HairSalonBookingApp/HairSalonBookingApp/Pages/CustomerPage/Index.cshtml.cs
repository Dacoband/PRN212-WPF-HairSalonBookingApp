using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.CustomerPage
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public IndexModel(ICustomerService customerService  )
        {
            _customerService = customerService;
        }

        public List<Customer> Customers { get; set; }

        public async Task OnGetAsync()
        {
            Customers = await _customerService.GetAllCustomers();
        }
    }
}

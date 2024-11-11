using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.StaffManagerPage
{
    public class IndexModel : PageModel
    {
        private readonly IStaffManagerService _staffManagerService;
        private readonly IAccountService _accountService;

        [BindProperty]
        public List<StaffManager> StaffManagers { get; set; } = new List<StaffManager>();

        public IndexModel(IStaffManagerService staffManagerService, IAccountService accountService)
        {
            _staffManagerService = staffManagerService;
            _accountService = accountService;
        }
        public async Task OnGet()
        {
            StaffManagers = await _staffManagerService.GetAllStaffManager();
        }
    }
}

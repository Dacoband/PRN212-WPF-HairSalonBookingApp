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
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(IStaffManagerService staffManagerService, IAccountService accountService)
        {
            _staffManagerService = staffManagerService;
            _accountService = accountService;
        }
        public async Task OnGet()
        {
            var allStaff = await _staffManagerService.GetAllStaffManager();
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                StaffManagers = allStaff
                    .Where(s => s.StaffManagerName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                                s.Account.Email.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            else
            {
                StaffManagers = allStaff;
            }
        }
    }
}

using HairSalonBookingApp.BusinessObjects.DTOs.StaffManager;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalonBookingApp.Pages.StaffManagerPage
{
    public class CreateModel : PageModel
    {
        private readonly IStaffManagerService _staffManagerService;
        private readonly IBranchService _branchService;

        public CreateModel(IStaffManagerService staffManagerService, IBranchService branchService)
        {
            _staffManagerService = staffManagerService;
            _branchService = branchService;
        }

        [BindProperty]
        public CreateStaffManagerRequest CreateStaffManagerRequest { get; set; }
        public List<Branch> Branches { get; set; } = new List<Branch>();

        public async Task OnGetAsync()
        {
            Branches = await _branchService.GetAllBranchNotStaffManager();
        }
        public async Task<IActionResult> OnPostAsync()
        {
                var result = await _staffManagerService.CreateStaffManager(CreateStaffManagerRequest);
                if (result)
                {
                TempData["success"] = "Staff manager created successfully.";
                return RedirectToPage("/StaffManagerPage/Index");
                }
                else
                {
                    TempData["error"] = "Failed to create staff manager.";
                return Page();
            }
        }
    }
}

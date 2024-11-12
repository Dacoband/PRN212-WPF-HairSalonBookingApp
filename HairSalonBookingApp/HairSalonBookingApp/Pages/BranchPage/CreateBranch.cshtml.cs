using HairSalonBookingApp.BusinessObjects.DTOs.Branch;
using HairSalonBookingApp.BusinessObjects.DTOs.Stylist;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.BranchPage
{
    public class CreateBranchModel : PageModel
    {
        private readonly IBranchService _branchService;
        private readonly IStaffManagerService _staffManagerService;

        [BindProperty]
        public CreateBracnhRequest Branch { get; set; }
       

        public List<StaffManager> StaffManagers { get; set; } = new List<StaffManager>();

        public CreateBranchModel(IBranchService branchService, IStaffManagerService staffManagerService)
        {
            _branchService = branchService;
            _staffManagerService = staffManagerService;
        }

        public async Task OnGetAsync()
        {
            // Lấy danh sách staff managers từ database
            StaffManagers = await _staffManagerService.GetAllStaffManager();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _branchService.AddBranch(Branch);
            if (result)
            {
                TempData["SuccessMessage"] = "Branch created successfully!";
                return RedirectToPage("/BranchPage/List"); // Redirect đến trang danh sách branch
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to create branch!";
                return Page();
            }
        }
    }
}

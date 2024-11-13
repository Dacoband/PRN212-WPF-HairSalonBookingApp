using HairSalonBookingApp.BusinessObjects.DTOs.StaffStylist;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.StaffStylistPage
{
    public class CreateStaffStylistModelModel : PageModel
    {
        private readonly IStaffStylistService _staffStylistService;
        private readonly IBranchService _branchService;

        public CreateStaffStylistModelModel(IStaffStylistService staffStylistService, IBranchService branchService)
        {
            _staffStylistService = staffStylistService;
            _branchService = branchService;
        }

        public List<Branch> Branches { get; set; } = new List<Branch>();
        [BindProperty]
        public CreateStaffStylistRequest CreateStaffStylistRequest { get; set; }

        public async Task OnGetAsync()
        {
            Branches = await _branchService.GetAllBranches();
        }

        public async Task<IActionResult> OnPostAsync()
        {        
            var success = await _staffStylistService.CreateStaffStylist(CreateStaffStylistRequest);
            if (success)
            {
                TempData["success"] = "Staff stylist created successfully.";
                return RedirectToPage("/StaffStylistPage/Index");
            }

            TempData["error"] = "Failed to create staff stylist.";
            return Page();
        }
    }
}

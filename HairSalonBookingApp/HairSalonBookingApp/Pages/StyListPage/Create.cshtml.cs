using HairSalonBookingApp.BusinessObjects.DTOs.Stylist;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.StyListPage
{
    public class CreateModel : PageModel
    {
        private readonly IStylistService _stylistService;
        private readonly IBranchService _branchService;
        private readonly IStaffStylistService _staffStylistService;

        public CreateModel(IStylistService stylistService, IBranchService branchService, IStaffStylistService staffStylistService)
        {
            _stylistService = stylistService;
            _branchService = branchService;
            _staffStylistService = staffStylistService;
        }

        [BindProperty]
        public CreateStylistRequest Stylist { get; set; } = new();

        public List<Branch> Branches { get; set; } = new();
        public List<StaffStylist> StaffStylists { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
           
            Branches = await _branchService.GetAllBranches();
            StaffStylists = await _staffStylistService.GetStaffStylists();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var success = await _stylistService.CreateStylist(Stylist);

            if (success)
            {
                TempData["success"] = "Stylist created successfully!";
                return RedirectToPage("/StyListPage/Index");
            }

            TempData["error"] = "Failed to create Stylist";
            return Page();
        }
    }
}

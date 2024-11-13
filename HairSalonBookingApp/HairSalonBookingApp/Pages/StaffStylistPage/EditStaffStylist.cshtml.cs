using HairSalonBookingApp.BusinessObjects.DTOs.StaffStylist;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.StaffStylistPage
{
    public class EditStaffStylistModel : PageModel
    {
        private readonly IStaffStylistService _staffStylistService;
        private readonly IBranchService _branchService;

        public EditStaffStylistModel(IStaffStylistService staffStylistService, IBranchService branchService)
        {
            _staffStylistService = staffStylistService;
            _branchService = branchService;
        }

        [BindProperty]
        public StaffStylist StaffStylist { get; set; }

        public List<Branch> Branches { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            // Get staff stylist information by ID
            StaffStylist = await _staffStylistService.GetStaffStylistById(id);
            if (StaffStylist == null)
            {
                return NotFound();
            }

            // Get list of branches for dropdown
            Branches = await _branchService.GetAllBranches();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var updateRequest = new UpdateStaffStylistRequest
            {
                Id = id,
                StaffStylistName = StaffStylist.StaffStylistName,
                DateOfBirth = StaffStylist.DateOfBirth,
                PhoneNumber = StaffStylist.PhoneNumber,
                Address = StaffStylist.Address,
                BranchID = StaffStylist.BranchID,
                AvatarImage = Request.Form.Files.FirstOrDefault() // AvatarImage file can be retrieved here
            };

            // Call update method
            var (success, message) = await _staffStylistService.UpdateStaffStylist(updateRequest);

            TempData["Message"] = message;

            // Redirect based on result
            if (success)
            {
                return RedirectToPage("StaffStylistList"); // Redirect to list page after update
            }

            return RedirectToPage();
        }
    }
}

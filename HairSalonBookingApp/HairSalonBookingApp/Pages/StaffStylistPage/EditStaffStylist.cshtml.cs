using HairSalonBookingApp.BusinessObjects.DTOs.StaffStylist;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.StaffStylistPage
{
    public class EditStaffStylistModel : PageModel
    {
        private readonly IStaffStylistService _staffStylistService;
        private readonly IBranchRepository _branchRepository;

        public EditStaffStylistModel(IStaffStylistService staffStylistService, IBranchRepository branchRepository)
        {
            _staffStylistService = staffStylistService;
            _branchRepository = branchRepository;
        }

        [BindProperty]
        public UpdateStaffStylistRequest UpdateStaffStylistRequest { get; set; }

        public StaffStylist StaffStylist { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            StaffStylist = await _staffStylistService.GetStaffStylistById(id);
            if (StaffStylist == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var success = await _staffStylistService.UpdateStaffStylist(UpdateStaffStylistRequest);
            if (success.Item1)
            {
                return RedirectToPage("Index");
            }

            TempData["ErrorMessage"] = success.Item2;
            return Page();
        }
    
    }
}

using HairSalonBookingApp.BusinessObjects.DTOs.StaffStylist;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.StaffStylistPage
{
    public class CreateStaffStylistModel : PageModel
    {
        private readonly IStaffStylistService _staffStylistService;

        public CreateStaffStylistModel(IStaffStylistService staffStylistService)
        {
            _staffStylistService = staffStylistService;
        }

        [BindProperty]
        public CreateStaffStylistRequest CreateStaffStylistRequest { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var success = await _staffStylistService.CreateStaffStylist(CreateStaffStylistRequest);
            if (success)
            {
                return RedirectToPage("Index");
            }

            TempData["ErrorMessage"] = "Failed to create staff stylist.";
            return Page();
        }
    }
}

using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.StaffStylistPage
{
    public class Index1Model : PageModel
    {
        private readonly IStaffStylistService _staffStylistService;

        public Index1Model(IStaffStylistService staffStylistService)
        {
            _staffStylistService = staffStylistService;
        }

        public List<StaffStylist> StaffStylists { get; set; }

        public async Task OnGetAsync()
        {
            StaffStylists = await _staffStylistService.GetStaffStylists();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var success = await _staffStylistService.DeleteStaffStylist(id);
            if (!success)
            {
                TempData["ErrorMessage"] = "Failed to delete staff stylist.";
                return RedirectToPage();
            }
            return RedirectToPage();
        }
    }
}

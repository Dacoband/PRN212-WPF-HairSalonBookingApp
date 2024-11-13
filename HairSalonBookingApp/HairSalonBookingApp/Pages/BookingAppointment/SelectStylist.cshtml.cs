using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.BookingAppointment
{
    [Authorize(Roles = "Customer")]
    public class SelectStylistModel : PageModel
    {
        [BindProperty]
        public List<Stylist> Stylists { get; set; } = new();


        private readonly IStylistService _stylistService;

        public SelectStylistModel(IStylistService stylistService)
        {
            _stylistService = stylistService;
        }
        public async Task OnGet(string branchId)
        {
            var branchIdGuid = Guid.Parse(branchId);
            Stylists = await _stylistService.GetAllStylists(x => x.BranchID == branchIdGuid);
        }
    }
}

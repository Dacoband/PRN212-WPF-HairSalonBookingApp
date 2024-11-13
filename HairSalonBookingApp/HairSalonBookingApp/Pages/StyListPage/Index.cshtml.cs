using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Services;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.StyListPage
{
    public class IndexModel : PageModel
    {
        private readonly IStylistService _stylistService;
        
       
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(IStylistService stylistService, IHttpContextAccessor httpContextAccessor)
        {
            _stylistService = stylistService;
        }
        [BindProperty]
        public List<Stylist> Stylists { get; set; } = new List<Stylist>();

        public async Task OnGetAsync()
        {
            var allStylist = await _stylistService.GetAllStylists();
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Stylists = allStylist
                    .Where(s => s.StylistName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                                s.Branch.SalonBranches.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            else
            {
                Stylists = allStylist;
            }
        }
    }
}

using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.StyListPage
{
    public class IndexModel : PageModel
    {
        private readonly IStylistService _stylistService;

        public IndexModel(IStylistService stylistService)
        {
            _stylistService = stylistService;
        }

        public List<Stylist> Stylists { get; set; } = new();

        public async Task OnGetAsync()
        {
            Stylists = await _stylistService.GetAllStylists();
        }
    }
}

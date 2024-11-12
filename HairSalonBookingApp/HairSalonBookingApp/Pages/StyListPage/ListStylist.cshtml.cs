using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.StyListPage
{
    public class ListStylistModel : PageModel
    {
        private readonly IStylistService _stylistService;

        public ListStylistModel(IStylistService stylistService)
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

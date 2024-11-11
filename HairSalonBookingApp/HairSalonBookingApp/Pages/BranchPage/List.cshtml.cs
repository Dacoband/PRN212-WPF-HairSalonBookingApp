using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.BranchPage
{
    public class ListModel : PageModel
    {
        private readonly IBranchService _branchService;
        private readonly IStylistService _stylistService;


        public ListModel(IBranchService branchService, IStylistService stylistService)
        {
            _branchService = branchService;
            _stylistService = stylistService;
        }

        public List<Branch> Branches { get; set; } = new List<Branch>();
        public List<Stylist> Stylists { get; set; }
        public Guid BranchId { get; set; }
        public async Task<IActionResult> OnPostGetStylistsAsync(string branchId)
        {
            BranchId = Guid.Parse(branchId);
            Stylists = await _stylistService.GetAllStlistByBranchId(BranchId);
            return new JsonResult(Stylists);
        }
        public async Task OnGetAsync()
        {
            Branches = await _branchService.GetAllBranches();
        }
    }
}

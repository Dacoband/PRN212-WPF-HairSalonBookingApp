using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using HairSalonBookingApp.Helper;
using HairSalonBookingApp.Services;

namespace HairSalonBookingApp.Pages.BranchPage
{
    public class ListModel : PageModel
    {
        private readonly IBranchService _branchService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public List<Service> SelectedServices { get; set; } 


        public List<Branch> Branches { get; set; } = new List<Branch>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } 


        public ListModel(IBranchService branchService, IHttpContextAccessor httpContextAccessor)
        {
            _branchService = branchService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task OnGetAsync()
        {
            var allBranches = await _branchService.GetAllBranches();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Branches = allBranches
                    .Where(b => b.SalonBranches.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                                b.Address.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            else
            {
                Branches = allBranches;
            }

            SelectedServices = HttpContext.Session.GetObjectFromJson<List<Service>>("selectedServices") ?? new List<Service>();

        }


        public IActionResult OnPostSelectBranch(int branchId)
        {
            HttpContext.Session.SetInt32("SelectedBranchId", branchId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var success = await _branchService.DeleteBranch(id);
            if (success)
            {
                TempData["success"] = "Branch deleted successfully.";
                return RedirectToPage();
            }

            TempData["error"] = "Failed to delete branch.";
            return RedirectToPage();
        }

    }
}

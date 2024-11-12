using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.BranchPage
{
    public class ListModel : PageModel
    {
        private readonly IBranchService _branchService;
        


        public ListModel(IBranchService branchService)
        {
            _branchService = branchService;
           
        }

        public List<Branch> Branches { get; set; } = new List<Branch>();
        public async Task OnGetAsync()
        {
            Branches = await _branchService.GetAllBranches();
        }
        public IActionResult OnPostSelectBranch(int branchId)
        {
            
            HttpContext.Session.SetInt32("SelectedBranchId", branchId);
            return RedirectToPage();
        }
    }
}

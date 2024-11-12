using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using HairSalonBookingApp.Helper;

namespace HairSalonBookingApp.Pages.BranchPage
{
    public class ListModel : PageModel
    {
        private readonly IBranchService _branchService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Dịch vụ đã chọn
        public List<Service> SelectedServices { get; set; }

        // Danh sách chi nhánh
        public List<Branch> Branches { get; set; } = new List<Branch>();

        // Constructor
        public ListModel(IBranchService branchService, IHttpContextAccessor httpContextAccessor)
        {
            _branchService = branchService;
            _httpContextAccessor = httpContextAccessor;
        }

        // Lấy tất cả các chi nhánh và dịch vụ đã chọn từ session
        public async Task OnGetAsync()
        {
            // Lấy danh sách chi nhánh
            Branches = await _branchService.GetAllBranches();

            // Lấy danh sách dịch vụ đã chọn từ session
            SelectedServices = HttpContext.Session.GetObjectFromJson<List<Service>>("selectedServices") ?? new List<Service>();

        }

        // Chọn chi nhánh và lưu vào session
        public IActionResult OnPostSelectBranch(int branchId)
        {
            HttpContext.Session.SetInt32("SelectedBranchId", branchId);
            return RedirectToPage();
        }
    }
}

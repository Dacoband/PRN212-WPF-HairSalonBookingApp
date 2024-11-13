using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalonBookingApp.Pages.AdminPage
{
    [Authorize(Roles = "Admin,StaffManager,StaffStylist")]
    public class ListFunctionsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

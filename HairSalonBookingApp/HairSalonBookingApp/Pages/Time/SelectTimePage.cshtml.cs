using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Pages.Time
{
    public class SelectTimePageModel : PageModel
    {
        public DateTime selectedDate { get; set; } = DateTime.Today;
        public DateTime? selectedTime { get; set; }

        public void OnGet()
        {
        }

        [HttpPost]
        public JsonResult OnPostUpdateDate([FromBody] DateTime date)
        {
            selectedDate = date;
            selectedTime = null; // Reset thời gian đã chọn khi thay đổi ngày
            return new JsonResult(new { success = true });
        }

        public void SelectTime(DateTime time)
        {
            selectedTime = time;
        }
    }
}

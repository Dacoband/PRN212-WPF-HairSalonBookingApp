using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Service.Interface;
using HairSalonBookingApp.Service.Payload.Request.Feedback;
using HairSalonBookingApp.BusinessObjects.Enum;

namespace HairSalonBookingApp.Pages.Feedbacks
{
    public class DeleteModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;

        public DeleteModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [BindProperty]
      public Feedback Feedback { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();
            try
            {
                Feedback = await _feedbackService.GetExistedFeedbackByIdAsync(id.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();

            //Replace Role and RequestCreateById with actual Id
            DeleteFeedbackRequest request = new DeleteFeedbackRequest(Guid.Parse("8AB5740C-8A20-48E4-0234-08DCFA95BF63"), RoleEnum.Customer, id.Value);
            try
            {
                await _feedbackService.DeleteFeedbackAsync(request);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return RedirectToPage("./Index");
        }
    }
}

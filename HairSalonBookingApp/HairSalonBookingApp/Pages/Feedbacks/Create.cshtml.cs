using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalonBookingApp.Service.Interface;
using HairSalonBookingApp.Service.Payload.Request.Feedback;
using HairSalonBookingApp.BusinessObjects.Entities;
using Newtonsoft.Json;

namespace HairSalonBookingApp.Pages.Feedbacks
{
    public class CreateModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IStylistService _stylistService;

        [BindProperty]
        public CreateFeedbackRequest Feedback { get; set; } = new CreateFeedbackRequest();
        public List<Stylist> Stylists { get; set; }

        public CreateModel(IFeedbackService feedbackService, IStylistService stylistService)
        {
            _feedbackService = feedbackService;
            _stylistService = stylistService;
        }

        public async void OnGetAsync()
        {
            if (Stylists == null)
                Stylists = await _stylistService.getAllStylistAsync(null, null);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Stylists = await _stylistService.getAllStylistAsync(null, null);
                return Page();
            }

            try
            {
                Feedback.CustomerId = Guid.Parse("8AB5740C-8A20-48E4-0234-08DCFA95BF63"); //test
                if (!await _feedbackService.CreateFeedback(Feedback))
                    throw new Exception();
                else
                    return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating feedback.");
                return Page();
            }
        }
    }
}

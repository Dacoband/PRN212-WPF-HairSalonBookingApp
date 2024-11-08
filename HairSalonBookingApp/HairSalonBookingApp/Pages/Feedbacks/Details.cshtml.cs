using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Service.Interface;

namespace HairSalonBookingApp.Pages.Feedbacks
{
    public class DetailsModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;

        public DetailsModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

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
    }
}

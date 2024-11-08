using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using HairSalonBookingApp.Service.Interface;
using HairSalonBookingApp.BusinessObjects.Enum;

namespace HairSalonBookingApp.Pages.Feedbacks
{
    public class EditModel : PageModel
    {
        private IFeedbackService _feedbackService;

        public EditModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [BindProperty]
        public Feedback Feedback { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Feedback = await _feedbackService.GetExistedFeedbackByIdAsync(id.Value);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            //TODO: Modify this to check Role and Id
            if (RoleEnum.Customer.Equals(RoleEnum.Customer))
            {
                Feedback.UpdDate = DateTime.Now;

                try
                {
                    await _feedbackService.UpdateFeedbackAsync(Feedback);
                }
                catch (Exception)
                {
                    return BadRequest();
                }

                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}

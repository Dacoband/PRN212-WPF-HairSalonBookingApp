using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using HairSalonBookingApp.Service.Interface;
using HairSalonBookingApp.BusinessObjects.Enum;

namespace HairSalonBookingApp.Pages.Feedbacks
{
    public class IndexModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;

        public IndexModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public IList<Feedback> Feedback { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //TODO: Modify this
            if (RoleEnum.Admin.Equals(RoleEnum.Admin))
                Feedback = await _feedbackService.GetAllFeedbacksAsync(ft => ft.DelFlg == false);
            else if (RoleEnum.Customer.Equals(RoleEnum.Customer))
                Feedback = await _feedbackService.GetAllFeedbacksAsync(ft => ft.DelFlg == false && ft.CustomerID.Equals("") /*AccountId here*/);
            else if (RoleEnum.Stylist.Equals(RoleEnum.Stylist))
                Feedback = await _feedbackService.GetAllFeedbacksAsync(ft => ft.DelFlg == false && ft.StylistID.Equals("") /*AccountId here*/);
        }
    }
}

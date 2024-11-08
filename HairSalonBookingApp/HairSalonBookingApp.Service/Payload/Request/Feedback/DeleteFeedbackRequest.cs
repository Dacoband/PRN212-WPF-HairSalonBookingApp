using HairSalonBookingApp.BusinessObjects.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Service.Payload.Request.Feedback
{
    public class DeleteFeedbackRequest
    {
        public Guid RequestCreateById { get; set; }
        public RoleEnum Role { get; set; }
        public Guid FeedbackId { get; set; }

        public DeleteFeedbackRequest(Guid requestCreateById, RoleEnum role, Guid feedbackId)
        {
            RequestCreateById = requestCreateById;
            Role = role;
            FeedbackId = feedbackId;
        }
    }
}

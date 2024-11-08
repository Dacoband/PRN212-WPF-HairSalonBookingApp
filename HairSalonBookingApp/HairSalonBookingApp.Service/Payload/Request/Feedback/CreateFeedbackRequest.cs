using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Service.Payload.Request.Feedback
{
    public class CreateFeedbackRequest
    {
        public Guid CustomerId { get; set; }
        public Guid StylistId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}

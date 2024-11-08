using HairSalonBookingApp.BusinessObjects.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Service
{
    public class UpdateFeedbackRequest
    {
        public Guid RequestCreateById { get; set; }
        public RoleEnum Role { get; set; }
        public Guid FeedbackId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.DTOs.Notification
{
    public class CreateNewNotificationRequest
    {
        public Guid MemberId { get; set; }
        public string Message { get; set; }
    }
}

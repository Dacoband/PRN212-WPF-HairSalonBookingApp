using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Notification
    {
        //PK
        public Guid NotificationId { get; set; }
        //FK from Member
        public Guid MemberId { get; set; }
        public string Message { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
       public bool DelFlg { get; set; }
    }
}

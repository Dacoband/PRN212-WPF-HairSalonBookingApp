using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class AppointmentCancellation
    {
        //PK
        public Guid CancellationId { get; set; }
        //FK from Appointment
        public Guid AppointmentId { get; set; }
        public string Reason { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }
    }
}

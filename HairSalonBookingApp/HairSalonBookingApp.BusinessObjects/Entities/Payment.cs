using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Payment
    {
        //PK
        public int PaymentId { get; set; }
        //FK from Appointment
        public int AppointmentId { get; set; }
        public float Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Status { get; set; } 
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }
    }
}

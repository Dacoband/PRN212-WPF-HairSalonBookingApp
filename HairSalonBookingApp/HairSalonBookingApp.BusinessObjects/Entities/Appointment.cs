using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Appointment
    {
        //PK
        public Guid AppointmentId { get; set; }
        //FK from Customer
        public Guid CustomerId { get; set; }
        //FK from Stylist
        public Guid StylistId { get; set; }
        public int Status { get; set; }
        public float TotalPrice { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        //FK from AppointmentService
        public virtual ICollection<AppointmentService> AppointmentService { get; set; } = new List<AppointmentService>();
    }
}

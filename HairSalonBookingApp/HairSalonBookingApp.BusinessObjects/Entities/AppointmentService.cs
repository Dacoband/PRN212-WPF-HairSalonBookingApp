using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class AppointmentService
    {
        //FK from Service
        public Guid ServiceId { get; set; }
        //FK from Appointment
        public Guid AppointmentId { get; set; }
        public float UnitPrice { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class Appointment
    {
        public Appointment()
        {
            AppointmentCancellations = new HashSet<AppointmentCancellation>();
            AppointmentServices = new HashSet<AppointmentService>();
            Payments = new HashSet<Payment>();
        }

        public Guid AppointmentId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid StylistId { get; set; }
        public string Status { get; set; } = null!;
        public float TotalPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Stylist Stylist { get; set; } = null!;
        public virtual ICollection<AppointmentCancellation> AppointmentCancellations { get; set; }
        public virtual ICollection<AppointmentService> AppointmentServices { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}

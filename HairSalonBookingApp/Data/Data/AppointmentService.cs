using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class AppointmentService
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public Guid AppointmentId { get; set; }
        public float UnitPrice { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }

        public virtual Appointment Appointment { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class AppointmentCancellation
    {
        public Guid CancellationId { get; set; }
        public Guid AppointmentId { get; set; }
        public string Reason { get; set; } = null!;
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }

        public virtual Appointment Appointment { get; set; } = null!;
    }
}

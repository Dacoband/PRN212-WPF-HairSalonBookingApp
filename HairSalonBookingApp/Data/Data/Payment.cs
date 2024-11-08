using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public Guid AppointmentId { get; set; }
        public float Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; } = null!;
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }

        public virtual Appointment Appointment { get; set; } = null!;
    }
}

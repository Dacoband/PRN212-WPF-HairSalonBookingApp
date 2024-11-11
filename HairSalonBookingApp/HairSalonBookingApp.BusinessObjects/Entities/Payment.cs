using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Payment : BaseEntity
    {
        public Payment() : base() { }
        //PK
        [Key]
        [Column("PaymentId")]
        public override Guid Id { get; set; }
        //FK from Appointment
        public Guid AppointmentId { get; set; }
        public float Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; } = string.Empty;

        [ForeignKey("AppointmentId")]
        public virtual Appointment Appointment { get; set; } = null!;
    }
}

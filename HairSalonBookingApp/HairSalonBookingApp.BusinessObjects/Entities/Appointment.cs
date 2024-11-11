using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Appointment : BaseEntity
    {
        public Appointment() : base() { }
        //PK
        [Key]
        [Column("AppointmentId")]
        public override Guid Id { get; set; }
        //FK from Customer
        public Guid CustomerId { get; set; }
        //FK from Stylist
        public Guid StylistId { get; set; }
        public string Status { get; set; } = string.Empty;
        public float TotalPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        //FK from AppointmentService
        public virtual ICollection<AppointmentService> AppointmentService { get; set; } = new List<AppointmentService>();

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey("StylistId")]
        public virtual Stylist Stylist { get; set; } = null!;
    }
}

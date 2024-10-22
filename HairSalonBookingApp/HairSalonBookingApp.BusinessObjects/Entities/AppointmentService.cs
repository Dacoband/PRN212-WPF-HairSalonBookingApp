using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class AppointmentService : BaseEntity
    {
        public AppointmentService() : base() { }
        [Key]
        public Guid Id { get; set; }
        //FK from Service
        public Guid ServiceId { get; set; }
        //FK from Appointment
        public Guid AppointmentId { get; set; }
        public float UnitPrice { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; } = null!;
    }
}
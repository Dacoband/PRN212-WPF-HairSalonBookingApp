using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Feedback : BaseEntity
    {
        [Key]
        [Column("FeedbackId")]
        public override Guid Id { get; set; }
        
        public Guid CustomerId { get; set; }
        
        public Guid StylistId { get; set; }
       
        public int Rating { get; set; }

        public string? Comment { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey("StylistId")]
        public virtual StaffStylist StaffStylist { get; set; } = null!;

    }
}

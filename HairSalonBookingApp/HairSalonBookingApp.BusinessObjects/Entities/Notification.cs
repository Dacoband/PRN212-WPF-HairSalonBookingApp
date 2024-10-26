using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Notification : BaseEntity
    {
        public Notification() : base() { }
        //PK
        [Key]
        public Guid NotificationId { get; set; }
        //FK from Member
        public Guid MemberId { get; set; }
        public string Message { get; set; } = string.Empty;

        [ForeignKey("MemberId")]
        public virtual Customer Member { get; set; } = null!;
    }
}

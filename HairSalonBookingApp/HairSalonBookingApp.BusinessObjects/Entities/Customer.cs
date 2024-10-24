using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Customer : BaseEntity
    {
        public Customer() : base() { }
        //PK
        [Key]
        public Guid CustomerId { get; set; }
        //FK from Account
        public Guid AccountId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string AvatarImage { get; set; } = string.Empty;

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; } = null!;
    }
}

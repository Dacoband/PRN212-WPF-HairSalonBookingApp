using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Account : BaseEntity
    {
        public Account() : base() { }
        //PK
        [Key]
        [Column("AccountId")]
        public override Guid Id { get; set; }
        public string RoleName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

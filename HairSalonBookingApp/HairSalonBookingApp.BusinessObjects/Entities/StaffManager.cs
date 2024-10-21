using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class StaffManager : BaseEntity
    {
        //PK
        [Key]
        public Guid StaffManagerID { get; set; }
        //FK from Branch
        public Guid? BranchID { get; set; }
        //FK from Account
        public Guid AccountID { get; set; }
        public string StaffManagerName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string AvatarImage { get; set; } = string.Empty; // Max size constraint not set here


        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; } = null!;
    }
}

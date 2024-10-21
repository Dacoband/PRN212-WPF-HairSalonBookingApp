using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class StaffManager
    {
        //PK
        public Guid StaffManagerID { get; set; }
        //FK from Branch
        public Guid BranchID { get; set; }
        //FK from Account
        public Guid AccountID { get; set; }
        public string StaffManagerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string AvatarImage { get; set; } = string.Empty; // Max size constraint not set here
        public DateTime? InsDate { get; set; }
        public DateTime? UpdDate { get; set; }
        public bool? DelFlg { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Branch
    {
        //PK
        public Guid BranchID { get; set; }
        //FK from StaffManager
        public Guid StaffManagerID { get; set; }
        public string SalonBranches { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }
    }
}

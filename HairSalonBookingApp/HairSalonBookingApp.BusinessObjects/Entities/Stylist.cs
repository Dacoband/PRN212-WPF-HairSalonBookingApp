using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Stylist
    {
        //PK
        public Guid StylistId { get; set; }
        //FK from Account
        public Guid AccountId { get; set; }
        //FK from Branch
        public Guid BranchID { get; set; }
        //FK from StaffStylist
        public Guid StaffStylistId { get; set; }
        public string StylistName { get; set; }
        public int Level { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string AvatarImage { get; set; }
        public string Master { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }
    }
}

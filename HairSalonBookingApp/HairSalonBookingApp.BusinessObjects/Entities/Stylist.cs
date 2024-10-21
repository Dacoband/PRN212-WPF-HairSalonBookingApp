using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Stylist : BaseEntity
    {
        [Key]
        public Guid StylistId { get; set; }
        //FK from Account
        public Guid AccountId { get; set; }
        //FK from Branch
        public Guid BranchID { get; set; }
        //FK from StaffStylist
        public Guid StaffStylistId { get; set; }
        public string StylistName { get; set; } = string.Empty;
        public int Level { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string AvatarImage { get; set; } = string.Empty;
        public string Master { get; set; } = string.Empty;

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; } = null!;
        [ForeignKey("BranchID")]
        public virtual Branch Branch { get; set; } = null!;
        [ForeignKey("StaffStylistId")]
        public virtual StaffStylist StaffStylist { get; set; } = null!;
    }
}

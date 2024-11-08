using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class StaffStylist
    {
        public StaffStylist()
        {
            Stylists = new HashSet<Stylist>();
        }

        public Guid StaffStylistId { get; set; }
        public Guid BranchID { get; set; }
        public Guid AccountId { get; set; }
        public string StaffStylistName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string AvatarImage { get; set; } = null!;
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Branch Branch { get; set; } = null!;
        public virtual ICollection<Stylist> Stylists { get; set; }
    }
}

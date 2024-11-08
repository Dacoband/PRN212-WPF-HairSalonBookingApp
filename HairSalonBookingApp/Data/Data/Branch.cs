using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class Branch
    {
        public Branch()
        {
            StaffStylists = new HashSet<StaffStylist>();
            Stylists = new HashSet<Stylist>();
        }

        public Guid BranchID { get; set; }
        public Guid StaffManagerID { get; set; }
        public string SalonBranches { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }

        public virtual StaffManager StaffManager { get; set; } = null!;
        public virtual ICollection<StaffStylist> StaffStylists { get; set; }
        public virtual ICollection<Stylist> Stylists { get; set; }
    }
}

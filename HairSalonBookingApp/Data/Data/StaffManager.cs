using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class StaffManager
    {
        public StaffManager()
        {
            Branches = new HashSet<Branch>();
        }

        public Guid StaffManagerID { get; set; }
        public Guid? BranchID { get; set; }
        public Guid AccountID { get; set; }
        public string StaffManagerName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string AvatarImage { get; set; } = null!;
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Branch> Branches { get; set; }
    }
}

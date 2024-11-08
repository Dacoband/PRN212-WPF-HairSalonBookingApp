using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class Account
    {
        public Account()
        {
            Customers = new HashSet<Customer>();
            StaffManagers = new HashSet<StaffManager>();
            StaffStylists = new HashSet<StaffStylist>();
            Stylists = new HashSet<Stylist>();
        }

        public Guid AccountId { get; set; }
        public string RoleName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<StaffManager> StaffManagers { get; set; }
        public virtual ICollection<StaffStylist> StaffStylists { get; set; }
        public virtual ICollection<Stylist> Stylists { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class Stylist
    {
        public Stylist()
        {
            Appointments = new HashSet<Appointment>();
            Feedbacks = new HashSet<Feedback>();
        }

        public Guid StylistId { get; set; }
        public Guid AccountId { get; set; }
        public Guid BranchID { get; set; }
        public Guid StaffStylistId { get; set; }
        public string StylistName { get; set; } = null!;
        public int Level { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string AvatarImage { get; set; } = null!;
        public string Master { get; set; } = null!;
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Branch Branch { get; set; } = null!;
        public virtual StaffStylist StaffStylist { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}

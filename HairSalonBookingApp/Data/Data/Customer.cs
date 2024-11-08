using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Appointments = new HashSet<Appointment>();
            Feedbacks = new HashSet<Feedback>();
            Notifications = new HashSet<Notification>();
        }

        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string AvatarImage { get; set; } = null!;
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}

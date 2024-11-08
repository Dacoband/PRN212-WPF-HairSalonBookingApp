using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class Service
    {
        public Service()
        {
            AppointmentServices = new HashSet<AppointmentService>();
        }

        public Guid ServiceID { get; set; }
        public string ServiceName { get; set; } = null!;
        public float Price { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public string? AvatarImage { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }

        public virtual ICollection<AppointmentService> AppointmentServices { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Service
    {
        //PK
        public Guid ServiceID { get; set; }
        public string ServiceName { get; set; }
        public int Type = 1;
        public float Price { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; } // minutes
        public string? AvatarImage { get; set; }
        public DateTime InsDate = DateTime.Now;
        public DateTime? UpdDate { get; set; }
        public bool DelFlg = true;
        //FK from AppointmentService
        public virtual ICollection<AppointmentService> AppointmentService { get; set; } = new List<AppointmentService>();
    }
}

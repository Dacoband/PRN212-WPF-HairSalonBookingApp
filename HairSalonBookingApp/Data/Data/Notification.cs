using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class Notification
    {
        public Guid NotificationId { get; set; }
        public Guid MemberId { get; set; }
        public string Message { get; set; } = null!;
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool DelFlg { get; set; }

        public virtual Customer Member { get; set; } = null!;
    }
}

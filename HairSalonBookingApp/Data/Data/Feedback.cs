using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class Feedback
    {
        public Guid FeedbackID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid? StylistID { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime? UpdDate { get; set; }
        public bool DelFlg { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Stylist? Stylist { get; set; }
    }
}

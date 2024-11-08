using HairSalonBookingApp.BusinessObjects.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    [Table("Feedback")]
    public class Feedback : BaseEntity
    {
        [Key]
        public Guid FeedbackID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid? StylistID { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }

        public virtual Customer? Customer { get; set; } = null!;
        public virtual Stylist? Stylist { get; set; }

        public Feedback(Guid customerID, Guid? stylistID, int? rating, string? comment)
        {
            FeedbackID = Guid.NewGuid();
            CustomerID = customerID;
            StylistID = stylistID;
            Rating = rating;
            Comment = comment;
            DelFlg = false;
            InsDate = DateTime.Now;
            UpdDate = DateTime.Now;
        }

        public Feedback()
        {
        }
    }
}

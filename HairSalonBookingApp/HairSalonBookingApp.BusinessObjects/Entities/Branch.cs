using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class Branch : BaseEntity
    {
        public Branch() : base() { }
        [Key]
        [Column("BranchID")]
        public override Guid Id { get; set; }

        //FK from StaffManager
        public Guid? StaffManagerID { get; set; }
        public string SalonBranches { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;


        [ForeignKey("StaffManagerID")]
        public virtual StaffManager StaffManager { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.DTOs.Branch
{
    public class CreateBracnhRequest
    {
        public Guid StaffManagerID { get; set; }
        public string SalonBranches { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}

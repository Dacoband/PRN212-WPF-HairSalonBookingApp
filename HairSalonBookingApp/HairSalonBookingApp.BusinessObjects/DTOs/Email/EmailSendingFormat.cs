using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.DTOs.Email
{
    public class EmailSendingFormat
    {
        [Required]
        public string Information { get; set; }
        [Required]
        public string Subject { get; set; } = "";
        [Required]
        public string member { get; set; }
    }
}

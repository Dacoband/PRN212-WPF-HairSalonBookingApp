using HairSalonBookingApp.BusinessObjects.DTOs.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services.Interface
{
    public interface IEmailService
    {
        public Task SendEmail(EmailSendingFormat sendingFormat);
    }
}

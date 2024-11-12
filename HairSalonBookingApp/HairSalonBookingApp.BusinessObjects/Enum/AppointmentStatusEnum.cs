using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Enum
{
    public enum AppointmentStatusEnum
    {
        Created,
        Paid,
        CancelledByCust,
        CancelledByStylist,
        Completed
    }
}

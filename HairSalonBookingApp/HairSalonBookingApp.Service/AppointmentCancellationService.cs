using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Service
{
    public class AppointmentCancellationService : IAppoinmentCancellationService
    {
        private readonly IAppointmentCancellationRepository _appointmentCancellationRepository;

        public AppointmentCancellationService(IAppointmentCancellationRepository appointmentCancellationRepository)
        {
            _appointmentCancellationRepository = appointmentCancellationRepository;
        }
    }
}

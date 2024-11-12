using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services
{
    public class AppointmentServiceService : IAppointmentServiceService
    {
        private readonly IAppointmentServiceRepository _appointmentServiceRepository;

        public AppointmentServiceService(IAppointmentServiceRepository appointmentServiceRepository)
        {
            _appointmentServiceRepository = appointmentServiceRepository;
        }
    }
}

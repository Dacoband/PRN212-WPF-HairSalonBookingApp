using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Service
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

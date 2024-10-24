using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO
{
    public class AppointmentDAO : BaseDAO<Appointment>
    {
        private static AppointmentDAO? _instance;
        public static AppointmentDAO Instance => _instance ??= new AppointmentDAO(new ApplicationDbContext());
        public AppointmentDAO(ApplicationDbContext context) : base(context)
        {
        }
    }
}

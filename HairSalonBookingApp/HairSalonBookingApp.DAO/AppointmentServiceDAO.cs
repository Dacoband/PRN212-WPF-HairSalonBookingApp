using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO
{
    public class AppointmentServiceDAO : BaseDAO<AppointmentService>
    {
        private static AppointmentServiceDAO? _instance;
        public static AppointmentServiceDAO Instance => _instance ??= new AppointmentServiceDAO(new ApplicationDbContext());
        public AppointmentServiceDAO(ApplicationDbContext context) : base(context)
        {
        }
    }
}

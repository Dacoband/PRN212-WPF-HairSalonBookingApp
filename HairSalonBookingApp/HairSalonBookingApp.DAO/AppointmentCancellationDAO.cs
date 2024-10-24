using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO
{
    public class AppointmentCancellationDAO : BaseDAO<AppointmentCancellation>
    {
        private static AppointmentCancellationDAO? _instance;
        public static AppointmentCancellationDAO Instance => _instance ??= new AppointmentCancellationDAO(new ApplicationDbContext());
        public AppointmentCancellationDAO(ApplicationDbContext context) : base(context)
        {
        }
    }
}

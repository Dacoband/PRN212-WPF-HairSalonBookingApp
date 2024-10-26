using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO
{
    public class NotificationDAO : BaseDAO<Notification>
    {
        private static NotificationDAO? _instance;
        public static NotificationDAO Instance => _instance ??= new NotificationDAO(new ApplicationDbContext());
        public NotificationDAO(ApplicationDbContext context) : base(context)
        {
        }
    }
}

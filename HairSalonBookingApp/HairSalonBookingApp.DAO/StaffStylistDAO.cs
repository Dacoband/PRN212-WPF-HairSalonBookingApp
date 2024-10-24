using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO
{
    public class StaffStylistDAO : BaseDAO<StaffStylist>
    {
        private static StaffStylistDAO? _instance;
        public static StaffStylistDAO Instance => _instance ??= new StaffStylistDAO(new ApplicationDbContext());
        public StaffStylistDAO(ApplicationDbContext context) : base(context)
        {
        }
    }
}

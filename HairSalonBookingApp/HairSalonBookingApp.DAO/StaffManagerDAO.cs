using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO
{
    public class StaffManagerDAO : BaseDAO<StaffManager>
    {
        private static StaffManagerDAO? _instance;
        public static StaffManagerDAO Instance => _instance ??= new StaffManagerDAO(new ApplicationDbContext());
        public StaffManagerDAO(ApplicationDbContext context) : base(context)
        {
        }
    }
}

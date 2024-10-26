using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO
{
    public class ServiceDAO : BaseDAO<Service>
    {
        private static ServiceDAO? instance;
        public static ServiceDAO Instance => instance ??= new ServiceDAO(new ApplicationDbContext());
        public ServiceDAO(ApplicationDbContext context) : base(context)
        {
        }
    }
}

using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO
{
    public class CustomerDAO : BaseDAO<Customer>
    {
        private static CustomerDAO? _instance;
        public static CustomerDAO Instance => _instance ??= new CustomerDAO(new ApplicationDbContext());
        public CustomerDAO(ApplicationDbContext context) : base(context)
        {
        }
    }
}

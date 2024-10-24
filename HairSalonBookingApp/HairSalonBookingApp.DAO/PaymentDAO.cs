using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO
{
    public class PaymentDAO : BaseDAO<Payment>
    {
        private static PaymentDAO? _instance;
        public static PaymentDAO Instance => _instance ??= new PaymentDAO(new ApplicationDbContext());
        public PaymentDAO(ApplicationDbContext context) : base(context)
        {
        }
    }
}

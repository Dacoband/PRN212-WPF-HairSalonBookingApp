using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO
{
    public class StylistDAO : BaseDAO<Stylist>
    {
        private static StylistDAO? _instance;
        public static StylistDAO Instance => _instance ??= new StylistDAO(new ApplicationDbContext());
        public StylistDAO(ApplicationDbContext context) : base(context)
        {
        }
    }
}

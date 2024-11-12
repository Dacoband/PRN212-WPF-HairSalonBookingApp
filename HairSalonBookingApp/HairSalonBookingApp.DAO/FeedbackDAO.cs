using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO
{
    public class FeedbackDAO : BaseDAO<Feedback>    
    {
        private static FeedbackDAO? _instance;
        public static FeedbackDAO Instance => _instance ??= new FeedbackDAO(new ApplicationDbContext());
        public FeedbackDAO(ApplicationDbContext context) : base(context)
        {
        }
    }
}

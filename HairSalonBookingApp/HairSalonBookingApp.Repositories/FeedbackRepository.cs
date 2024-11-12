using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO;
using HairSalonBookingApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Repositories
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository() : base(FeedbackDAO.Instance)
        {
        }

        public async Task<Feedback?> GetByCustomerId(Guid customerId)
        {
            return await FeedbackDAO.Instance.GetAsync(x => x.CustomerId == customerId);
        }

        public async Task<IEnumerable<Feedback?>> GetByStylistId(Guid stylistId)
        {
            return await FeedbackDAO.Instance.GetAllAsync(x => x.StylistId == stylistId);
        }

        public async Task UpdateStylistAverageRatingAsync(Guid stylistId, double averageRating)
        {
            var stylist = await StylistDAO.Instance.GetAsync(stylistId);
            if (stylist != null)
            {
                stylist.AverageRating = averageRating;
                await StylistDAO.Instance.UpdateAsync(stylist);
            }
        }
    }
}

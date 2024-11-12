using HairSalonBookingApp.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Repositories.Interface
{
    public interface IFeedbackRepository :IRepository<Feedback>
    {
        Task<Feedback?> GetByCustomerId(Guid customerId); 
        Task<IEnumerable<Feedback?>> GetByStylistId(Guid stylistId);
        Task UpdateStylistAverageRatingAsync(Guid stylistId, double averageRating);

    }
}

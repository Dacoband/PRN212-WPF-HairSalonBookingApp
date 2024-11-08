using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Service.Payload.Request.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Service.Interface
{
    public interface IFeedbackService
    {
        Task<List<Feedback>> GetAllFeedbacksAsync(Expression<Func<Feedback, bool>> filter, bool? orderByInsDate = false, bool? orderByUdpDate = false);
        Task<bool> CreateFeedback(CreateFeedbackRequest request);
        Task<Feedback> GetExistedFeedbackByIdAsync(Guid feedbackId);
        Task<bool> DeleteFeedbackAsync(DeleteFeedbackRequest request);
        Task<bool> UpdateFeedbackAsync(Feedback feedback);
    }
}

using HairSalonBookingApp.BusinessObjects.DTOs.Feedback;
using HairSalonBookingApp.BusinessObjects.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services.Interface
{
    public interface IFeedbackService
    {
        Task<Feedback?> GetByCustomerId(Guid customerId);
        Task<IEnumerable<Feedback?>> GetByStylistId(Guid stylistId);
        Task<Feedback?> GetFeedbackById(Guid id);
        Task<List<Feedback>> GetAllFeedbacks();
        Task<(bool,string)> AddFeedback(CreateFeedbackRequest createFeedbackRequest);
        Task<bool> DeleteFeedback(Guid id);
    }
}

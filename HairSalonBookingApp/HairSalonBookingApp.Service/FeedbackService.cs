using HairSalonBookingApp.BusinessObjects.DTOs.Feedback;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IStylistRepository _stylistRepository;
        private readonly IAccountRepository _accountRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository, ICustomerRepository customerRepository, IStylistRepository stylistRepository, IAccountRepository accountRepository)
        {
            _feedbackRepository = feedbackRepository;
            _customerRepository = customerRepository;
            _stylistRepository = stylistRepository;
            _accountRepository = accountRepository;
        }

        public async Task<(bool,string)> AddFeedback(CreateFeedbackRequest createFeedbackRequest)
        {
            string message;
            try
            {
                var stylist = await _stylistRepository.GetAsync(createFeedbackRequest.StylistId);
                if (stylist == null)
                {
                    message = "Stylist not found";
                    return (false, message);
                }
                var customer = await _customerRepository.GetAsync(createFeedbackRequest.CustomerId);
                var account = await _accountRepository.GetAsync(customer.AccountId);
                var feedback = new Feedback
                {
                    Id = Guid.NewGuid(),
                    CustomerId = account.Id,
                    StylistId = createFeedbackRequest.StylistId,
                    Rating = createFeedbackRequest.Rating,
                    Comment = createFeedbackRequest.Comment
                };
                await _feedbackRepository.AddAsync(feedback);
                await UpdateAverageRating(createFeedbackRequest.StylistId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return (false, message);
            }
            message = "Feedback added successfully";
            return (true, message);
        }

        public async Task UpdateAverageRating(Guid stylistId)
        {
            string message;
            try
            {
                var feedbacks = await _feedbackRepository.GetByStylistId(stylistId);

                if (feedbacks != null && feedbacks.Any()) 
                {
                    double averageRating = feedbacks.Average(f => f.Rating);
                    var stylist = await _stylistRepository.GetAsync(stylistId);
                    stylist.AverageRating = averageRating;
                    _stylistRepository.Update(stylist);
                }
                else
                {
                    message = "No feedback found for the stylist.";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

        public async Task<bool> DeleteFeedback(Guid id)
        {
            string message;
            try
            {
                var feedback = await _feedbackRepository.GetAsync(id);
                if (feedback == null)
                {
                    message = "Feedback not found";
                    return false;
                }
                feedback.DelFlg = true;
                _feedbackRepository.Update(feedback);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            message = "Feedback deleted successfully";
            return true;
        }

        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            var feedbacks = await _feedbackRepository.GetAllAsync();
            return feedbacks.ToList();
        }

        public async Task<Feedback?> GetByCustomerId(Guid customerId)
        {
            string message;
            var feedback = await _feedbackRepository.GetByCustomerId(customerId);
            if (feedback == null)
            {
                message = "Feedback not found";
                return null;
            }
            return feedback;
        }

        public async Task<IEnumerable<Feedback?>> GetByStylistId(Guid stylistId)
        {
            string message;
            var feedback = await _feedbackRepository.GetByStylistId(stylistId);
            if (feedback == null)
            {
                message = "Feedback not found";
                return null;
            }
            return feedback.ToList();
        }

        public async Task<Feedback?> GetFeedbackById(Guid id)
        {
           var feedback = await _feedbackRepository.GetAsync(id);
            return feedback;
        }
    }
}

using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.BusinessObjects.Enum;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Service.Interface;
using HairSalonBookingApp.Service.Payload.Request.Feedback;
using System.Linq.Expressions;

namespace HairSalonBookingApp.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IStylistRepository _stylistRepository;
        private readonly IAccountRepository _accountRepository;

        protected static string FEEDBACK_NOT_FOUND = "Không tìm thấy feedback.";
        protected static string CUSTOMER_NOT_FOUND = "Không tìm thấy khách hàng.";
        protected static string STYLIST_NOT_FOUND = "Không tìm thấy stylist.";
        protected static string RATING_VALIDATION_FAILED = "Điểm đánh giá không được nhỏ hơn 0 hoặc lớn hơn 5.";
        protected static string CREATED_BY_DIFFERENCE_CUSTOMER = "Bạn không có quyền chỉnh sửa feedback này.";
        protected static string NOT_ALLOW = "Bạn không có quyền thực hiện hành động này.";

        public FeedbackService(IFeedbackRepository feedbackRepository, ICustomerRepository customerRepository, IStylistRepository stylistRepository, IAccountRepository accountRepository)
        {
            _feedbackRepository = feedbackRepository;
            _customerRepository = customerRepository;
            _stylistRepository = stylistRepository;
            _accountRepository = accountRepository;
        }

        public Feedback? GetFeedbackById(Guid id)
        {
            return _feedbackRepository.Get(fb => fb.FeedbackID == id && fb.DelFlg == false, includeProperties: "Customer,Stylist");
        }

        public Feedback GetExistedFeedbackById(Guid feedbackId)
        {
            Feedback? feedback = GetFeedbackById(feedbackId);
            if (feedback == null)
                throw new Exception(RATING_VALIDATION_FAILED);
            return feedback;
        }

        public async Task<Feedback> GetExistedFeedbackByIdAsync(Guid feedbackId)
        {
            Feedback? feedback = await _feedbackRepository.GetAsync(fb => fb.FeedbackID == feedbackId, includeProperties: "Customer,Stylist");
            if (feedback == null)
                throw new Exception(RATING_VALIDATION_FAILED);
            return feedback;
        }

        public async Task<List<Feedback>> GetAllFeedbacksAsync(Expression<Func<Feedback, bool>>? filter = null, bool? orderByInsDate = false, bool? orderByUpdDate = false)
        {
            var query = await _feedbackRepository.GetAllAsync(filter ?? (fb => fb.DelFlg == false), includeProperties: "Customer,Stylist");

            if (orderByInsDate == true && orderByUpdDate == true)
            {
                query = query.OrderBy(fb => fb.InsDate).ThenBy(fb => fb.UpdDate);
            }
            else if (orderByInsDate == true)
            {
                query = query.OrderBy(fb => fb.InsDate);
            }
            else if (orderByUpdDate == true)
            {
                query = query.OrderBy(fb => fb.UpdDate);
            }

            return query.ToList();
        }


        public async Task<bool> CreateFeedback(CreateFeedbackRequest request)
        {
            Customer? customer = _customerRepository.Get(cus => cus.CustomerId == request.CustomerId);
            if (customer == null)
                throw new Exception(CUSTOMER_NOT_FOUND);

            Stylist? stylist = _stylistRepository.Get(sl => sl.StylistId == request.StylistId);
            if (stylist == null)
                throw new Exception(STYLIST_NOT_FOUND);

            if (request.Rating < 0 || request.Rating > 5)
                throw new Exception();

            Feedback _feedback = new Feedback(request.CustomerId, request.StylistId, request.Rating, request.Comment);
            return await _feedbackRepository.AddAsync(_feedback);
        }

        public bool DeleteFeedbackById(Guid feedbackId)
        {
            Feedback feedback = GetExistedFeedbackById(feedbackId);
            return _feedbackRepository.Delete(feedback);
        }

        public bool UpdateFeedback(UpdateFeedbackRequest request)
        {
            if (RoleEnum.Customer.Equals(request.Role))
            {
                Customer? customer = _customerRepository.Get(cus => cus.CustomerId == request.RequestCreateById);
                if (customer == null)
                    throw new Exception(CUSTOMER_NOT_FOUND);
                Feedback feedback = GetExistedFeedbackById(request.FeedbackId);

                if (feedback.CustomerID != customer.CustomerId)
                    throw new Exception(CREATED_BY_DIFFERENCE_CUSTOMER);
                feedback.Rating = request.Rating;
                feedback.Comment = request.Comment;

                return _feedbackRepository.Update(feedback);
            }
            else if (RoleEnum.Admin.Equals(request.Role))
            {
                Feedback feedback = GetExistedFeedbackById(request.FeedbackId);
                feedback.Rating = request.Rating;
                feedback.Comment = request.Comment;
                return _feedbackRepository.Update(feedback);
            }
            else
                throw new Exception(NOT_ALLOW);
        }

        public async Task<bool> DeleteFeedbackAsync(DeleteFeedbackRequest request)
        {
            if (RoleEnum.Admin.Equals(request.Role))
                return await DoDeleteFeedbackAsync(GetExistedFeedbackById(request.FeedbackId));
            else if (RoleEnum.Customer.Equals(request.Role))
            {
                Customer? customer = _customerRepository.Get(cus => cus.CustomerId == request.RequestCreateById);
                if (customer == null)
                    throw new Exception(CUSTOMER_NOT_FOUND);

                Feedback feedback = GetExistedFeedbackById(request.FeedbackId);

                if (!feedback.CustomerID.Equals(request.RequestCreateById))
                    throw new Exception(NOT_ALLOW);

                return await DoDeleteFeedbackAsync(feedback);
            } 
            else throw new Exception(NOT_ALLOW);
        }

        public async Task<bool> DoDeleteFeedbackAsync(Feedback feedback)
        {
            feedback.DelFlg = true;
            feedback.UpdDate = DateTime.Now;
            return await _feedbackRepository.UpdateAsync(feedback);
        }

        public async Task<bool> UpdateFeedbackAsync(Feedback feedback)
        {
            return await _feedbackRepository.UpdateAsync(feedback);
        }
    }
}

using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.BusinessObjects.DTOs.Notification;
using HairSalonBookingApp.Repositories;
namespace HairSalonBookingApp.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public async Task<List<Notification>> GetAllNotification()
        {
            try
            {
                var notifications = await _notificationRepository.GetAllAsync();
                return notifications.ToList();
            }
            catch (Exception)
            {
                return new List<Notification>();
            }
        }
        public async Task<Notification> GetNotificationById(Guid id)
        {
            try
            {
                var notification = await _notificationRepository.GetAsync(id);
                return notification;
            }
            catch (Exception)
            {
                return new Notification();
            }
        }
        public async Task<bool> CreateNotification(CreateNewNotificationRequest notificationRequest)
        {
            try
            {
                var notification = new Notification
                {
                    Id = Guid.NewGuid(),
                    MemberId = notificationRequest.MemberId,
                    Message = notificationRequest.Message,
                };
                await _notificationRepository.AddAsync(notification);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<(bool, string)> UpdateNotification(Guid id, UpdateNotificationRequest notificationRequest)
        {
            try
            {
                var notification = await _notificationRepository.GetAsync(id);
                if (notification == null)
                {
                    return (false, "Notification not found");
                }
                if (string.IsNullOrWhiteSpace(notificationRequest.Message))
                {
                    return (false, "Message cannot be empty");
                }
                notification.Message = notificationRequest.Message;
                if ( _notificationRepository.Update(notification))
                {
                    return (true, "Notification updated successfully");
                }

                return (false, "Notification update failed");
            }
            catch (Exception ex)
            {
                return (false, $"An error occurred: {ex.Message}");
            }
        }
        public async Task<bool> DeleteNotification(Guid id)
        {
            try
            {
                var notification= await _notificationRepository.GetAsync(id);
                if (notification == null)
                {
                    return false;
                }
                notification.DelFlg = true;
                _notificationRepository.Update(notification);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

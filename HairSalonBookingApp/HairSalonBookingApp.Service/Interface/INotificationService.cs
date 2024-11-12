using HairSalonBookingApp.BusinessObjects.DTOs.Notification;
using HairSalonBookingApp.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services.Interface
{
    public interface INotificationService
    {
        Task<List<Notification>> GetAllNotification();
        Task<Notification> GetNotificationById(Guid id);
        Task<bool> CreateNotification(CreateNewNotificationRequest notificationRequest);
        Task<bool> UpdateNotification(Guid id, UpdateNotificationRequest notificationRequest);
        Task<bool> DeleteNotification(Guid id);
        
    }
}

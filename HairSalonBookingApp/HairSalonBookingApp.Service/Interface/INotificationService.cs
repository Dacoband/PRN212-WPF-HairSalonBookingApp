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
        Task<bool> CreateNotification(Notification notification);
        Task<bool> UpdateNotification(Guid id, Notification notification);
        Task<bool> DeleteNotification(Guid id);
        
    }
}

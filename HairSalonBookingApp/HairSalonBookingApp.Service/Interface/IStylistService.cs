using HairSalonBookingApp.BusinessObjects.DTOs.Stylist;
using HairSalonBookingApp.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services.Interface
{
    public interface IStylistService
    {
        Task<Stylist?> GetStylistById(Guid stylistId);
        Task<List<Stylist>> GetAllStylists();
        Task<bool> CreateStylist(CreateStylistRequest createStylistRequest);
        Task<(bool, string)> UpdateStylist(UpdateStylistRequest updateStylistRequest);
        Task<bool> DeleteStylist(Guid stylistId);

        Task<List<Stylist>> GetAllStylists(Expression<Func<Stylist, bool>>? filter = null, string? includeProperties = null);
    }
}

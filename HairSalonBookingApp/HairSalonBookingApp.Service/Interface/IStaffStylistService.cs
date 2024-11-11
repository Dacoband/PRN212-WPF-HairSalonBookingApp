using HairSalonBookingApp.BusinessObjects.DTOs.StaffStylist;
using HairSalonBookingApp.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services.Interface
{
    public interface IStaffStylistService
    {
        Task<List<StaffStylist>> GetStaffStylists();
        Task<StaffStylist?> GetStaffStylistById(Guid staffId);
        Task<bool> CreateStaffStylist(CreateStaffStylistRequest createStaffStylistRequest);
        Task<bool> DeleteStaffStylist(Guid staffId);
        Task<(bool, string)> UpdateStaffStylist(UpdateStaffStylistRequest updateStaffStylistRequest);
    }
}

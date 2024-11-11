using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services
{
    public class StylistService : IStylistService
    {
        private readonly IStylistRepository _stylistRepository;

        public StylistService(IStylistRepository stylistRepository)
        {
            _stylistRepository = stylistRepository;
        }
        public async Task<List<Stylist>> GetAllStlistByBranchId(Guid id)
        {
            try
            {
                var stylists = await _stylistRepository.GetAllAsync(s => s.BranchID == id);
                return stylists.ToList();
            }
            catch (Exception)
            {
                return new List<Stylist>();
            }
        }
    }
}

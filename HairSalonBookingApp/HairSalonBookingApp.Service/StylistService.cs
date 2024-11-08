using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Service.Interface;
using System.Linq.Expressions;

namespace HairSalonBookingApp.Service
{
    public class StylistService : IStylistService
    {
        private readonly IStylistRepository _stylistRepository;

        public StylistService(IStylistRepository stylistRepository)
        {
            _stylistRepository = stylistRepository;
        }

        public async Task<List<Stylist>> getAllStylistAsync(Expression<Func<Stylist, bool>>? filter = null, string? include = null)
        {
            var query = await _stylistRepository.GetAllAsync(filter ?? (ft => true), include);
            return query.ToList();
        }
    }
}

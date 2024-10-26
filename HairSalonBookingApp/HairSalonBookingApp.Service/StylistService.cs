using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Service
{
    public class StylistService : IStylistService
    {
        private readonly IStylistRepository _stylistRepository;

        public StylistService(IStylistRepository stylistRepository)
        {
            _stylistRepository = stylistRepository;
        }
    }
}

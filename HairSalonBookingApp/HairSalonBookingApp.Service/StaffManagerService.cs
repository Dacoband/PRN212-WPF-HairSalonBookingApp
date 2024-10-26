using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Service
{
    public class StaffManagerService : IStaffManagerService
    {
        private readonly IStaffManagerRepository _staffManagerRepository;

        public StaffManagerService(IStaffManagerRepository staffManagerRepository)
        {
            _staffManagerRepository = staffManagerRepository;
        }
    }
}

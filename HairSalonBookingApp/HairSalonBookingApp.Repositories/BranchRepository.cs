using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO;
using HairSalonBookingApp.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Repositories
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository() : base(BranchDAO.Instance)
        {
        }
        public async Task<Branch?> GetBranchByStaffManagerID(Guid staffManagerID)
        {
            return await BranchDAO.Instance.GetAsync(x => x.StaffManagerID == staffManagerID);
        }
    }
}

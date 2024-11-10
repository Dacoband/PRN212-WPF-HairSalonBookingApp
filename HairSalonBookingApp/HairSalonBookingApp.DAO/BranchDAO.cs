using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO
{
    public class BranchDAO : BaseDAO<Branch>
    {
        private static BranchDAO? _instance;
        public static BranchDAO Instance => _instance ??= new BranchDAO(new ApplicationDbContext());
        public BranchDAO(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<Branch>> GetBranchesByManagerID(Guid staffManagerID)
        {
            return await Task.Run(() => _context.Branches.Where(b => b.StaffManagerID == staffManagerID).ToList());
        }
    }
}

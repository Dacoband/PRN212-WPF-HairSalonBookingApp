using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.DAO
{
    public class AccountDAO : BaseDAO<Account>
    {
        private static AccountDAO? _instance;
        public static AccountDAO Instance => _instance ??= new AccountDAO(new ApplicationDbContext());
        public AccountDAO(ApplicationDbContext context) : base(context) { }
        public Account? GetByEmail(string email)
        {
            return _dbSet.FirstOrDefault(a => a.Email == email);
        }
    }
}

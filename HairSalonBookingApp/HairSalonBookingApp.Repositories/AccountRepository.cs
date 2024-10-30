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
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly AccountDAO _accountDAO;
        public AccountRepository() : base(AccountDAO.Instance)
        {
            _accountDAO = AccountDAO.Instance;
        }
        public Account? GetByEmail(string email) => _accountDAO.GetByEmail(email);
    }
}

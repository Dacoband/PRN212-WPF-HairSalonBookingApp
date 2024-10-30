using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public bool RegisterAccount(string email, string password, string name, string phoneNumber)
        {
            var existingAccount = _accountRepository.GetByEmail(email);
            if (existingAccount != null)
            {
                return false;
            }
            var newAccount = new Account
            {
                AccountId = Guid.NewGuid(),
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                RoleName = "Customer"
            };
            var newCustomer = new Customer
            {
                CustomerId = Guid.NewGuid(),
                AccountId = newAccount.AccountId,
                CustomerName = name,
                PhoneNumber = phoneNumber
            };
            return _accountRepository.Add(newAccount);
        }

        public Account? Login(string email, string password)
        {
            var account = _accountRepository.GetByEmail(email);
            if (account != null && BCrypt.Net.BCrypt.Verify(password, account.Password))
            {
                return account;
            }
            return null;
        }
    }
}

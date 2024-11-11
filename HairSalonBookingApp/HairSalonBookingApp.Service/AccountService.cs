using FirebaseAdmin.Messaging;
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
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<bool> RegisterAccount(string email, string password, string? name = null, string? phoneNumber = null)
        {
            var existingAccount = _accountRepository.GetByEmail(email);
            if (existingAccount != null)
            {
                return false;
            }
            var newAccount = new Account
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                RoleName = "Customer"
            };
            var newCustomer = new Customer
            {
                Id = Guid.NewGuid(),
                AccountId = newAccount.Id,
                CustomerName = name,
                PhoneNumber = phoneNumber
            };
            return await _accountRepository.AddAsync(newAccount);
        }

        public async Task<(Account?, string)> Login(string email, string password)
        {
            string message = "Login failed";

            var account = await _accountRepository.GetAsync(a => a.Email == email);

            if (account == null)
            {
                message = "Email not found";
            }
            else if (!BCrypt.Net.BCrypt.Verify(password, account.Password))
            {
                message = "Invalid Password";
            }
            else if (account.DelFlg == true)
            {
                message = "Account is banned";
            }
            else
            {
                message = "Login successful";
                return (account, message);
            }

            return (null, message);
        }

        public Account? Register(string email, string password, string? name, out string message)
        {
            throw new NotImplementedException();
        }
    }
}

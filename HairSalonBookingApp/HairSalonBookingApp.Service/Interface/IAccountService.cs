using HairSalonBookingApp.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services.Interface
{
    public interface IAccountService
    {
        public Task<bool> RegisterAccount(string email, string password, string? name = null, string? phoneNumber = null);
        Account? Login(string email, string password);
    }
}

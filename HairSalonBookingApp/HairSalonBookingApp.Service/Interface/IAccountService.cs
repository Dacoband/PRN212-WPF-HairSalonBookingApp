using HairSalonBookingApp.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Service.Interface
{
    public interface IAccountService
    {
        public bool RegisterAccount(string email, string password, string name, string phoneNumber);
        Account? Login(string email, string password);
    }
}

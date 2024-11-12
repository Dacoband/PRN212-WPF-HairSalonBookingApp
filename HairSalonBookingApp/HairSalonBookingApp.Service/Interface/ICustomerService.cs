using HairSalonBookingApp.BusinessObjects.DTOs.Customer;
using HairSalonBookingApp.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services.Interface
{
    public interface ICustomerService
    {
        Task<Customer?> GetCustomerById(Guid customerId);
        Task<List<Customer>> GetAllCustomers();
        Task<(Account?, string)> CreateCustomer(CreateCustomerRequest createCustomerRequest);
        Task<(bool, string)> UpdateCustomer(UpdateCustomerRequest updateCustomerRequest);
        Task<bool> DeleteCustomer(Guid customerId);
    }
}

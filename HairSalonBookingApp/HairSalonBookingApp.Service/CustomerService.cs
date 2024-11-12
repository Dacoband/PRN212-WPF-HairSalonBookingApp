using HairSalonBookingApp.BusinessObjects.DTOs.Customer;
using HairSalonBookingApp.BusinessObjects.DTOs.Stylist;
using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.BusinessObjects.Enum;
using HairSalonBookingApp.Repositories;
using HairSalonBookingApp.Repositories.Interface;
using HairSalonBookingApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IFirebaseService _firebaseService;

        public CustomerService(ICustomerRepository customerRepository, IFirebaseService firebaseService, IAccountRepository accountRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> CreateCustomer(CreateCustomerRequest createCustomerRequest)
        {
            string message;
            try
            {
                var account = new Account
                {
                    Id = Guid.NewGuid(),
                    Email = createCustomerRequest.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(createCustomerRequest.Password),
                    RoleName = RoleEnum.Customer.ToString(),
                };
                await _accountRepository.AddAsync(account);
                var url = await _firebaseService.UploadFile(createCustomerRequest.AvatarImage);
                var customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    AccountId = account.Id,
                    CustomerName = createCustomerRequest.CustomerName,
                    DateOfBirth = createCustomerRequest.DateOfBirth,
                    PhoneNumber = createCustomerRequest.PhoneNumber,
                    Address = createCustomerRequest.Address,
                    AvatarImage = url
                };
                await _customerRepository.AddAsync(customer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                message = ex.Message;
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteCustomer(Guid customerId)
        {
            string message;
            try
            {
                var customer = await _customerRepository.GetAsync(customerId);
                if (customer == null)
                {
                    message = "Customer not found";
                    return false;
                }
                customer.DelFlg = true;
                _customerRepository.Update(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                message = ex.Message;
                return false;
            }
            message = "Delete customer successfully";
            return true;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.ToList();
        }

        public async Task<Customer?> GetCustomerById(Guid customerId)
        {
            var customer = await _customerRepository.GetAsync(customerId);
            if (customer == null)
            {
                return null;
            }
            return customer;
        }

        public async Task<(bool, string)> UpdateCustomer(UpdateCustomerRequest updateCustomerRequest)
        {
            string message;
            try
            {
                var customer = await _customerRepository.GetAsync(updateCustomerRequest.Id);
                if (customer == null)
                {
                    message = "Customer not found";
                    return (false, message);
                }
                var url = "";
                if (updateCustomerRequest.AvatarImage != null)
                {
                    url = await _firebaseService.UploadFile(updateCustomerRequest.AvatarImage);
                }
                customer.CustomerName = updateCustomerRequest.CustomerName ?? customer.CustomerName;
                customer.DateOfBirth = updateCustomerRequest.DateOfBirth ?? customer.DateOfBirth;
                customer.PhoneNumber = updateCustomerRequest.PhoneNumber ?? customer.PhoneNumber;
                customer.Address = updateCustomerRequest.Address ?? customer.Address;
                customer.AvatarImage = url ?? customer.AvatarImage;
                if (_customerRepository.Update(customer))
                {
                    message = "Update stylist successfully";
                    return (true, message);
                }
                else
                {
                    message = "Update stylist failed";
                    return (false, message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                message = ex.Message;
                return (false, message);
            }
        }
    }
}

using HairSalonBookingApp.BusinessObjects.DTOs.Service;
using HairSalonBookingApp.BusinessObjects.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Services.Interface
{
    public interface IServiceService
    {

        Task<(bool, string)> AddService(CreateNewServiceRequest service);
        Task<bool> UpdateService(Guid id, UpdateNewServiceRequest service);
        Task<ActionResult<List<Service>>> GetServiceList(QueryService query);
        Task<Service?> GetServiceById(Guid serviceId);
        Task<ActionResult> DeleteService(Guid serviceId);

    }
}

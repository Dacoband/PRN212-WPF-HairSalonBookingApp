﻿using HairSalonBookingApp.BusinessObjects.DTOs.Service;
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

        Task<bool> AddService(CreateNewServiceRequest service);
        Task<bool> UpdateService(Service service);
        Task<ActionResult<List<Service>>> GetServiceList(QueryService query);
        Task<ActionResult<Service>> GetServiceById(Guid serviceId);
        Task<ActionResult> DeleteService(Guid serviceId);

    }
}

using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairSalonBookingApp.BusinessObjects.DTOs.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using HairSalonBookingApp.Services.Interface;

namespace HairSalonBookingApp.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<bool> AddService(CreateNewServiceRequest service)
        {
            // var url = await _serviceRepository.UploadImage(service.AvatarImage);
            var newService = new Service
            {
                Id = Guid.NewGuid(),
                ServiceName = service.ServiceName,
                Type = service.Type,
                Price = service.Price,
                Description = service.Description,
                Duration = service.Duration,
                AvatarImage = null
            };

            return await _serviceRepository.AddAsync(newService);
        }
        public async Task<bool> UpdateService(Service service)
        {
            var oldService = await _serviceRepository.GetAsync(service.Id);
            if (oldService == null)
            {
                return false;
            }
            if (service.AvatarImage != null)
            {
                // var url = await _serviceRepository.UploadImage(service.AvatarImage);
                // oldService.AvatarImage = url;
            }
            oldService.ServiceName = service.ServiceName ?? oldService.ServiceName;
            oldService.Type = service.Type != 0 ? service.Type : oldService.Type;
            oldService.Price = service.Price != 0 ? service.Price : oldService.Price;
            oldService.Description = service.Description ?? oldService.Description;
            oldService.Duration = service.Duration != 0 ? service.Duration : oldService.Duration;
            oldService.UpdDate = DateTime.Now;

            return _serviceRepository.Update(oldService);
        }
        public async Task<ActionResult<List<Service>>> GetServiceList(QueryService query)
        {
            Expression<Func<Service, bool>> filter = s =>
                (string.IsNullOrEmpty(query.ServiceName) || s.ServiceName.ToLower() == query.ServiceName.ToLower()) &&
                (!query.Type.HasValue || s.Type == query.Type) &&
                (!query.MaxPrice.HasValue || s.Price <= query.MaxPrice) &&
                (!query.DelFig.HasValue || s.DelFlg == query.DelFig);
            var services = await _serviceRepository.GetWithPaginationAsync(
                pageNum: query.pageIndex ?? 0,
                pageSize: query.pageSize ?? 10,
                filter: filter
            );
            if (!services.Any())
            {
                return new ObjectResult("Không tìm thấy dịch vụ")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var resList = services.Select(service => new Service
            {
                Id = service.Id,
                ServiceName = service.ServiceName,
                Type = service.Type,
                Price = service.Price,
                Description = service.Description,
                Duration = service.Duration,
                AvatarImage = service.AvatarImage,
                InsDate = service.InsDate,
                UpdDate = service.UpdDate,
                DelFlg = service.DelFlg,
            }).ToList();

            return new OkObjectResult(resList);
        }
        public async Task<ActionResult<Service>> GetServiceById(Guid serviceId)
        {
            var service = await _serviceRepository.GetAsync(serviceId);
            if (service == null)
            {
                return new ObjectResult("Không tìm thấy dịch vụ")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var serviceResponse = new Service
            {
                Id = service.Id,
                ServiceName = service.ServiceName,
                Type = service.Type,
                Price = service.Price,
                Description = service.Description,
                Duration = service.Duration,
                AvatarImage = service.AvatarImage,
                InsDate = service.InsDate,
                UpdDate = service.UpdDate,
                DelFlg = service.DelFlg,
            };
            return new OkObjectResult(serviceResponse);
        }
        public async Task<ActionResult> DeleteService(Guid serviceId)
        {
            var service = await _serviceRepository.GetAsync(serviceId);

            if (service == null)
            {
                return new ObjectResult("Không tìm thấy dịch vụ")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            service.DelFlg = true;
            service.UpdDate = DateTime.Now;

            var isUpdated = _serviceRepository.Update(service);
            if (!isUpdated)
            {
                return new ObjectResult("Xóa không thành công")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            return new OkObjectResult("Xóa thành công");
        }



    }
}

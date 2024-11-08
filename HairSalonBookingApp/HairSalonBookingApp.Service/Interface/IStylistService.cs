using HairSalonBookingApp.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Service.Interface
{
    public interface IStylistService
    {
        Task<List<Stylist>> getAllStylistAsync(Expression<Func<Stylist, bool>>? filter = null, string? include = null);
    }
}

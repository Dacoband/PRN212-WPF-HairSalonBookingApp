﻿using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO;
using HairSalonBookingApp.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Repositories
{
    public class AppointmentCancellationRepository : Repository<AppointmentCancellation>, IAppointmentCancellationRepository
    {
        public AppointmentCancellationRepository() : base(AppointmentCancellationDAO.Instance)
        {
        }
    }
}
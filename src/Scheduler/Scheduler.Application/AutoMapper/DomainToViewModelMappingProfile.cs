using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Scheduler.Application.ViewModels;
using Scheduler.Domain.Models;

namespace Scheduler.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Appointment, AppointmentViewModel>();
        }
    }
}

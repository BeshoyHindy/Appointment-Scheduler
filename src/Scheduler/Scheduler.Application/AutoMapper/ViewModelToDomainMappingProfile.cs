using AutoMapper;
using Scheduler.Application.ViewModels;
using Scheduler.Domain.Commands;

namespace Scheduler.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AppointmentViewModel, AddNewAppointmentCommand>()
                .ConstructUsing(a => new AddNewAppointmentCommand(a.Name, a.Email, a.PhoneNumber, a.StartTime, a.EndTime, a.Date, a.Notes));
            CreateMap<AppointmentViewModel, UpdateAppointmentCommand>()
                .ConstructUsing(a => new UpdateAppointmentCommand(a.Id, a.Name, a.Email, a.PhoneNumber, a.StartTime, a.EndTime, a.Date, a.Notes));
        }
    }
}
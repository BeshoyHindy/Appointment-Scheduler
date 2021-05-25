using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using Scheduler.Application.Interfaces;
using Scheduler.Application.ViewModels;
using Scheduler.Domain.Commands;
using Scheduler.Domain.Core.Mediator;
using Scheduler.Domain.Interfaces;

namespace Scheduler.Application.Services
{
    public class AppointmentAppService : IAppointmentAppService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMediatorHandler _mediator;

        public AppointmentAppService(IMapper mapper,
                                  IAppointmentRepository appointmentRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _mediator = mediator;
        }

        public async Task<ValidationResult> Add(AppointmentViewModel appointmentViewModel)
        {
            var addCommand = _mapper.Map<AddNewAppointmentCommand>(appointmentViewModel);
            return await _mediator.SendCommand(addCommand);
        }

        public async Task<ValidationResult> Update(AppointmentViewModel appointmentViewModel)
        {
            var updateCommand = _mapper.Map<UpdateAppointmentCommand>(appointmentViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Delete(Guid id)
        {
            var deleteCommand = new RemoveAppointmentCommand(id);
            return await _mediator.SendCommand(deleteCommand);
        }

        public async Task<IEnumerable<AppointmentViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<AppointmentViewModel>>(await _appointmentRepository.GetAll());
        }

        public async Task<AppointmentViewModel> GetById(Guid id)
        {
            return _mapper.Map<AppointmentViewModel>(await _appointmentRepository.GetById(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

}

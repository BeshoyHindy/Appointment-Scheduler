using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using Scheduler.Domain.Core.Messaging;
using Scheduler.Domain.Events;
using Scheduler.Domain.Interfaces;
using Scheduler.Domain.Models;

namespace Scheduler.Domain.Commands
{
    public class AppointmentCommandHandler : CommandHandler,
        IRequestHandler<AddNewAppointmentCommand, ValidationResult>,
        IRequestHandler<UpdateAppointmentCommand, ValidationResult>,
        IRequestHandler<RemoveAppointmentCommand, ValidationResult>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<ValidationResult> Handle(AddNewAppointmentCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var appointment = new Appointment(Guid.NewGuid(), message.Name, message.Email,message.PhoneNumber, message.StartTime, message.EndTime,message.Date, message.Notes);

            appointment.AddDomainEvent(new AppointmentAddedEvent(appointment.Id, appointment.Name, appointment.Email, appointment.PhoneNumber, appointment.StartTime, appointment.EndTime, appointment.Date, appointment.Notes));

            _appointmentRepository.Add(appointment);

            return await Commit(_appointmentRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateAppointmentCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var appointment = new Appointment(message.Id, message.Name, message.Email, message.PhoneNumber, message.StartTime, message.EndTime, message.Date, message.Notes);

            appointment.AddDomainEvent(new AppointmentUpdatedEvent(appointment.Id, appointment.Name, appointment.Email, appointment.PhoneNumber, appointment.StartTime, appointment.EndTime, appointment.Date, appointment.Notes));

            _appointmentRepository.Update(appointment);

            return await Commit(_appointmentRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveAppointmentCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var appointment = await _appointmentRepository.GetById(message.Id);

            if (appointment is null)
            {
                AddError("The appointment doesn't exists.");
                return ValidationResult;
            }

            appointment.AddDomainEvent(new AppointmentRemovedEvent(message.Id));

            _appointmentRepository.Remove(appointment);

            return await Commit(_appointmentRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _appointmentRepository.Dispose();
        }
    }

}

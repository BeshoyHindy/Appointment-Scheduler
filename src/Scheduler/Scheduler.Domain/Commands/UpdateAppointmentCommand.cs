using System;
using Scheduler.Domain.Commands.Validations;

namespace Scheduler.Domain.Commands
{
    public class UpdateAppointmentCommand : AppointmentCommand
    {
        public UpdateAppointmentCommand(Guid id, string name, string email, string phoneNumber, DateTime startTime, DateTime endTime, DateTime date, string notes)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            StartTime = startTime;
            EndTime = endTime;
            Date = date;
            Notes = notes;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateAppointmentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
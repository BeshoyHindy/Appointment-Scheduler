using System;
using Scheduler.Domain.Commands.Validations;

namespace Scheduler.Domain.Commands
{
    public class AddNewAppointmentCommand : AppointmentCommand
    {
        public AddNewAppointmentCommand(string name, string email, string phoneNumber, DateTime startTime, DateTime endTime, DateTime date, string notes)
        {
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
            ValidationResult = new AddNewAppointmentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
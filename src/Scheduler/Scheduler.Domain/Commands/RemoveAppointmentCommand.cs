using System;
using Scheduler.Domain.Commands.Validations;

namespace Scheduler.Domain.Commands
{
    public class RemoveAppointmentCommand : AppointmentCommand
    {
        public RemoveAppointmentCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveAppointmentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
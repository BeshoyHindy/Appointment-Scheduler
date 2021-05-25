using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Scheduler.Domain.Commands.Validations
{
    public abstract class AppointmentValidation<T> : AbstractValidator<T> where T : AppointmentCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateStartTime()
        {
            RuleFor(c => c.StartTime)
                .NotEmpty()
                .Must(d => d != default)
                .WithMessage("Start date is required");

        }

        protected void ValidateEndTime()
        {
            RuleFor(c => c.EndTime)
                .NotEmpty()
                .Must(d => d != default)
                .WithMessage("End date is required");


            RuleFor(c => c.EndTime)
                .NotEmpty().WithMessage("End date is required")
                .GreaterThan(c => c.StartTime)
                .WithMessage("End date must after Start date")
                .When(m => m.StartTime != default);

        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }


    }
}

using System;
using FluentValidation.Results;
using MediatR;

namespace Scheduler.Domain.Core.Messaging
{
    public abstract class Query<TResponse> : Message, IRequest<TResponse>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Query()
        {
            Timestamp = DateTime.Now;
            ValidationResult = new ValidationResult();
        }

        public virtual bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
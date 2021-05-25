using System;
using Scheduler.Domain.Core.Messaging;

namespace Scheduler.Domain.Events
{
    public class AppointmentRemovedEvent : Event
    {
        public AppointmentRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
        public Guid Id { get; set; }
    }
}
using System;
using Scheduler.Domain.Core.Messaging;

namespace Scheduler.Domain.Events
{
    public class AppointmentAddedEvent : Event
    {
        public AppointmentAddedEvent(Guid id, string name, string email, string phoneNumber, DateTime startTime, DateTime endTime, DateTime date, string notes)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            StartTime = startTime;
            EndTime = endTime;
            Date = date;
            Notes = notes;
            AggregateId = id;
        }
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DateTime Date { get; private set; }
        public string Notes { get; private set; }
    }
}
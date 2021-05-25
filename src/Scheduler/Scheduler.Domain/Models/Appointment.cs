using Scheduler.Domain.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Domain.Models
{
    public class Appointment : Entity, IAggregateRoot
    {
        public Appointment(Guid id, string name, string email, string phoneNumber, DateTime startTime, DateTime endTime, DateTime date, string notes)
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

        // Empty constructor for EF
        protected Appointment() { }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string PhoneNumber { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DateTime Date { get; private set; }
        public string Notes { get; private set; }
    }
}

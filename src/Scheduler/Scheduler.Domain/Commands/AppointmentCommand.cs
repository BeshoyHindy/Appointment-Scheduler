using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheduler.Domain.Core.Messaging;

namespace Scheduler.Domain.Commands
{
    public abstract class AppointmentCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public string PhoneNumber { get; protected set; }
        public DateTime StartTime { get; protected set; }
        public DateTime EndTime { get; protected set; }
        public DateTime Date { get; protected set; }
        public string Notes { get; protected set; }
    }
}

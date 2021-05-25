using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Scheduler.Domain.Events
{
    public class AppointmentEventHandler :
        INotificationHandler<AppointmentAddedEvent>,
        INotificationHandler<AppointmentUpdatedEvent>,
        INotificationHandler<AppointmentRemovedEvent>
    {
        public Task Handle(AppointmentUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification

            return Task.CompletedTask;
        }

        public Task Handle(AppointmentAddedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification

            return Task.CompletedTask;
        }

        public Task Handle(AppointmentRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification

            return Task.CompletedTask;
        }
    }
}

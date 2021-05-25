using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using Scheduler.Domain.Core.Mediator;
using Scheduler.Domain.Core.Messaging;

namespace Scheduler.Domain.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task PublishEvent<T>(T @event) where T : Event
        {
            //if we using event sourcing then we should save the event in eventStore here.
            await _mediator.Publish(@event);
        }

        public Task<TResponse> GetQuery<TResponse, TQuery>(TQuery query) where TQuery : Query<TResponse>
        {
            return _mediator.Send(query);
        }

    }


}

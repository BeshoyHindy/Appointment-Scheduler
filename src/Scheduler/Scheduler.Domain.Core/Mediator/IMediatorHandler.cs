using System.Threading.Tasks;
using FluentValidation.Results;
using Scheduler.Domain.Core.Messaging;

namespace Scheduler.Domain.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<TResponse>(TResponse @event) where TResponse : Event;
        Task<ValidationResult> SendCommand<TResponse>(TResponse command) where TResponse : Command;
        Task<TResponse> GetQuery<TResponse, TQuery>(TQuery query) where TQuery : Query<TResponse>;

    }
}
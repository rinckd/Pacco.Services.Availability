using System.Threading.Tasks;
using Convey.CQRS.Events;

namespace Pacco.Services.Availability.Application.Events.External.Handlers
{
    internal sealed class CustomerCreatedHandler : IEventHandler<CustomerCreated>
    {
        public Task HandleAsync(CustomerCreated @event)
        {
            // Customer data could be saved into Availability DB depending on the business requirements.
            // Given the asynchronous nature of events, this would result in eventual consistency.
            return Task.CompletedTask;
        }
    }
}
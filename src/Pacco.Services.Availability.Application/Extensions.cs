using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Pacco.Services.Availability.Application
{
    public static class Extensions
    {
        public static IConveyBuilder AddApplication(this IConveyBuilder builder) => builder
            .AddCommandHandlers()
            .AddInMemoryCommandDispatcher()
            .AddEventHandlers()
            .AddInMemoryEventDispatcher();
    }
}
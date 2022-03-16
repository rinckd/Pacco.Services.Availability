using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Microsoft.Extensions.Logging;
using Pacco.Services.Availability.Application.Services;

namespace Pacco.Services.Availability.Infrastructure.Services
{
    internal sealed class MessageBroker : IMessageBroker
    {
        private readonly IBusPublisher _busPublisher;
        private readonly ILogger<MessageBroker> _logger;

        public MessageBroker(IBusPublisher busPublisher, ILogger<MessageBroker>logger)
        {
            _busPublisher = busPublisher;
            _logger = logger;
        }

        public Task PublishAsync(params IEvent[] events) => PublishAsync(events?.AsEnumerable());

        public async Task PublishAsync(IEnumerable<IEvent> events)
        {
            if (events is null)
            {
                return;
            }

            foreach (var @event in events)
            {
                if (@event is null)
                {
                    continue;
                }
                var messageId = Guid.NewGuid().ToString("N");
                _logger.LogTrace($"Publishing an integration event: '{@event.GetType().Name.Underscore()}'" + $"with Id: '{messageId}'");
                await _busPublisher.PublishAsync(@event, messageId);
            }
             
        }
    }
}
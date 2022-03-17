
using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Convey.MessageBrokers;
using Convey.MessageBrokers.Outbox;

namespace Pacco.Services.Availability.Infrastructure.Decorators
{
    internal sealed class OutboxCommandHandlerDecorator<T> : ICommandHandler<T> where T : class, ICommand
    {
        private readonly ICommandHandler<T> _handler;
        private readonly IMessageOutbox _outbox;
        private readonly bool _enabled;
        private readonly string _messageId;
        
        public OutboxCommandHandlerDecorator(ICommandHandler<T> handler, IMessageOutbox outbox,
            IMessagePropertiesAccessor messagePropertiesAccessor)
        {
            _handler = handler;
            _outbox = outbox;
            var messageProperties = messagePropertiesAccessor.MessageProperties;
            _messageId = string.IsNullOrWhiteSpace(messageProperties?.MessageId) 
                ? Guid.NewGuid().ToString("N") 
                : messageProperties.MessageId;
            _enabled = outbox.Enabled;
        }

        public Task HandleAsync(T command) => _enabled
            ? _outbox.HandleAsync(_messageId, () => _handler.HandleAsync(command))
            : _handler.HandleAsync(command);

    }
}
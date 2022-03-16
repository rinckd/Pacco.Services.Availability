using System;
using Convey.MessageBrokers.RabbitMQ;
using Pacco.Services.Availability.Application.Commands;
using Pacco.Services.Availability.Application.Events.Rejected;
using Pacco.Services.Availability.Application.Exceptions;
using Pacco.Services.Availability.Core.Exceptions;

namespace Pacco.Services.Availability.Infrastructure.Exceptions
{
    internal sealed class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(Exception exception, object message)
            => exception switch
            {
                MissingResourceTagsException ex => new AddResourceRejected(Guid.Empty, ex.Message,
                    ex.Code),
                InvalidResourceTagsException ex => new AddResourceRejected(Guid.Empty, ex.Message,
                    ex.Code),
                CannotExpropriateReservationException ex => new ReserveResourceRejected(ex.ResourceId, ex.Message, 
                    ex.Code),
                ResourceAlreadyExistsException ex => new AddResourceRejected(ex.Id, ex.Message,
                    ex.Code),
                ResourceNotFoundException ex => message switch
                {
                    ReserveResource command => new ReserveResourceRejected(command.ResourceId, 
                        ex.Message, ex.Code),
                    _ => null
                },
                _ => null
            };
    }
}
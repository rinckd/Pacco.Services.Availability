using System.Collections;
using System.Collections.Generic;
using Convey.CQRS.Events;
using Pacco.Services.Availability.Core.Events;

namespace Pacco.Services.Availability.Application.Services
{
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent domainEvent);
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> @events);
    }
}
using System;
using Convey.CQRS.Events;

namespace Pacco.Services.Availability.Application.Events.Rejected
{
    [Contract]
    public class ReserveResourceRejected : IRejectedEvent
    {
        public Guid ResourceId { get; }
        public string Reason { get; }
        public string Code { get; }

        public ReserveResourceRejected(Guid resourceId, string reason, string code)
        {
            ResourceId = resourceId;
            Reason = reason;
            Code = code;
        }
    }
}
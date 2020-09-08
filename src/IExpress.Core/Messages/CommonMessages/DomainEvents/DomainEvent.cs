using MediatR;
using System;

namespace IExpress.Core.Messages.CommonMessages.DomainEvents
{
    public class DomainEvent: Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
            Timestamp = DateTime.Now;
        }
    }
}

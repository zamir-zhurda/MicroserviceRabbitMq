using Microservice.RabbitMQ.Transfer.Domain.Events;
using Microservice.RabbitMQ.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.RabbitMQ.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvents>
    {
        public TransferEventHandler()
        {

        }
        public Task Handle(TransferCreatedEvents @event)
        {
            return Task.CompletedTask;
        }
    }
}

using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microservice.RabbitMQ.Domain.Core.Events;

namespace Microservice.RabbitMQ.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
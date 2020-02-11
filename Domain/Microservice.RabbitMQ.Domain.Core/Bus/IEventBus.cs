using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microservice.RabbitMQ.Domain.Core.Events;
using Microservice.RabbitMQ.Domain.Core.Commands;

namespace Microservice.RabbitMQ.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        ///I am using @event because event is a reserved word
        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, Thandler>()
                     where T : Event
                     where Thandler : IEventHandler<T>;
    }
}
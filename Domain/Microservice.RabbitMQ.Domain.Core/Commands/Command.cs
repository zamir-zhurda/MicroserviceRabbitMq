using System;
using System.Collections.Generic;
using Microservice.RabbitMQ.Domain.Core.Events;

namespace Microservice.RabbitMQ.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime TimeStamp { get; protected set; }

        public Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
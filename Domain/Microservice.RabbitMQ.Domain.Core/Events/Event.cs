using System;
namespace Microservice.RabbitMQ.Domain.Core.Events
{
    public abstract class Event
    {
        public DateTime Timestamp { get; protected set; }

        public Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
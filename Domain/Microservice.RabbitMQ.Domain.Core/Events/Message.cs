using MediatR;
namespace Microservice.RabbitMQ.Domain.Core.Events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        public string SenderName { get; protected set; }

        public string MessageDescription { get; protected set; }

        public Message()
        {
            MessageType = GetType().Name;
            //SenderName = GetType().FullName;
            //MessageDescription = GetType().;
        }
    }
}
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microservice.RabbitMQ.Domain.Core.Bus;
using Microservice.RabbitMQ.Domain.Core.Commands;
using Microservice.RabbitMQ.Domain.Core.Events;
using MediatR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using System.Linq;

namespace Microservice.RabbitMQ.Infra.Bus
{

    /* 
     We don't want some other class to extend this class 
     That is why we are making it sealed class
    */
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly Dictionary<string, List<Type>> _dictionaryHandlers;
        private readonly List<Type> _eventTypes;
        public RabbitMQBus(IMediator mediator)
        {
            _mediator = mediator;
            _dictionaryHandlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }
        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public void Publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var eventName = @event.GetType().Name;
                    channel.QueueDeclare(eventName, false, false, false, null);

                    var message = JsonConvert.SerializeObject(@event);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", eventName, null, body);
                }
            }
        }

        public void Subscribe<T, Thandler>() where T : Event where Thandler : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(Thandler);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if (!_dictionaryHandlers.ContainsKey(eventName))
            {
                _dictionaryHandlers.Add(eventName, new List<Type>());
            }

            if (_dictionaryHandlers[eventName].Any(handler => handler.GetType() == handlerType))
            {
                throw new ArgumentException($"The handler type {handlerType.Name} already is registered for the '{eventName}' ", nameof(handlerType));

            }
            _dictionaryHandlers[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }
        private void StartBasicConsume<T>() where T : Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "rabbitmq",
                // DispatchConsumerAsync = true
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var eventName = typeof(T).Name;

            channel.QueueDeclare(eventName, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += Consumer_Received; //Delegate pointer to the method;
            channel.BasicConsume(eventName, true, consumer);
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body);
            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }
            catch (Exception ex)
            {

            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_dictionaryHandlers.ContainsKey(eventName))
            {
                var subscribtions = _dictionaryHandlers[eventName];
                foreach (var subscription in subscribtions)
                {
                    var handler = Activator.CreateInstance(subscription);
                    if (handler == null) continue;
                    var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                    var @event = JsonConvert.DeserializeObject(message, eventType);
                    var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                    await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                }
            }
        }
    }
}
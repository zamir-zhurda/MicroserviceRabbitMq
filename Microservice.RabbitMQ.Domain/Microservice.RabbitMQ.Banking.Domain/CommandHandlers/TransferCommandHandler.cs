using MediatR;
using Microservice.RabbitMQ.Banking.Domain.Commands;
using Microservice.RabbitMQ.Banking.Domain.Events;
using Microservice.RabbitMQ.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.RabbitMQ.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _eventBus;
        public TransferCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {

            //publish event to rabbitMQ
            TransferCreatedEvents transferCreatedEvents = new TransferCreatedEvents(request.FromAccount,request.ToAccount,request.Amount);
            _eventBus.Publish(transferCreatedEvents);
           
            return Task.FromResult(true);
        }
    }
}

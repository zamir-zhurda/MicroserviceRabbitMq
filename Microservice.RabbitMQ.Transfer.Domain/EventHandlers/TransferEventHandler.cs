using Microservice.RabbitMQ.Transfer.Domain.Events;
using Microservice.RabbitMQ.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microservice.RabbitMQ.Transfer.Domain.Interfaces;
using Microservice.RabbitMQ.Transfer.Domain.Models;

namespace Microservice.RabbitMQ.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvents>
    {
        private readonly ITransferRepository _transferRepository;
        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }
        public Task Handle(TransferCreatedEvents @event)
        {
            TransferLog transferLog = new TransferLog();
            transferLog.FromAccount = @event.FromAccountSource;
            transferLog.ToAccount = @event.ToAccountDestination;
            transferLog.TransferAmount = transferLog.TransferAmount;
            _transferRepository.Add(transferLog);
            return Task.CompletedTask;
        }
    }
}

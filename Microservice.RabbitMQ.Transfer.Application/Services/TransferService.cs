using Microservice.RabbitMQ.Transfer.Application.Interfaces;
//using Microservice.RabbitMQ.Transfer.Application.ViewModel;
//using Microservice.RabbitMQ.Transfer.Domain.Commands;
using Microservice.RabbitMQ.Transfer.Domain.Interfaces;
using Microservice.RabbitMQ.Transfer.Domain.Models;
using Microservice.RabbitMQ.Domain.Core.Bus;
using System.Collections.Generic;

namespace Microservice.RabbitMQ.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _eventBus;

        public TransferService(ITransferRepository transferRepository, IEventBus eventBus)
        {
            _transferRepository = transferRepository;
            _eventBus = eventBus;
        }
        public IEnumerable<TransferLog> GetTransferLogs()
        {
          return  _transferRepository.GetTransferLogs();
        }

      
    }
}

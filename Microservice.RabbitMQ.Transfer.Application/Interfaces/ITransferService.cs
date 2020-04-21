
using Microservice.RabbitMQ.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.RabbitMQ.Transfer.Application.Interfaces
{
   public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
       
    }
}

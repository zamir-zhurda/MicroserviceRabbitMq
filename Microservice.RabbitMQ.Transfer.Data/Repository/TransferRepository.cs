using Microservice.RabbitMQ.Transfer.Data.DbContext;
using Microservice.RabbitMQ.Transfer.Domain.Interfaces;
using Microservice.RabbitMQ.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microservice.RabbitMQ.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext _transferDbContext;
        public TransferRepository(TransferDbContext transferDbContext)
        {
            _transferDbContext = transferDbContext;
        }
        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferDbContext.TransferLogs.ToList();
        }
    }
}

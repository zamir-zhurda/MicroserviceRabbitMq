using Microservice.RabbitMQ.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Microservice.RabbitMQ.Domain.Commands
{
   public class TransferCommand : Command
    {
        public int FromAccount { get; protected set; }
        public int  ToAccount { get; protected set; }

        public decimal Amount { get; protected set; }
    }
}

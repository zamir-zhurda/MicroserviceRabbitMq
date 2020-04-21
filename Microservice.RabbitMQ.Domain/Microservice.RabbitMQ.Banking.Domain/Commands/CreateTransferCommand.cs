using Microservice.RabbitMQ.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.RabbitMQ.Banking.Domain.Commands
{
    public class CreateTransferCommand : TransferCommand
    {
        public CreateTransferCommand(int fromAccount, int toAccount, decimal amount)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Amount = amount;
        }
    }
}

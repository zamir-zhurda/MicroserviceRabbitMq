using Microservice.RabbitMQ.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.RabbitMQ.Banking.Domain.Events
{
    public class TransferCreatedEvents :Event
    {
        public int FromAccountSource { get; private set; }
        public int ToAccountDestination { get; private set; }
        public decimal Amount { get; private set; }

        public TransferCreatedEvents(int fromAccount, int toAccount, decimal amount)
        {
            FromAccountSource = fromAccount;
            ToAccountDestination = toAccount;
            Amount = amount;
        }
    }
}

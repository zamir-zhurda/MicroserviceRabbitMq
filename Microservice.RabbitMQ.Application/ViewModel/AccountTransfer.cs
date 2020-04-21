using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.RabbitMQ.Banking.Application.ViewModel
{
    public class AccountTransfer
    {
        public int FromAccountSource { get; set; }

        public int ToAccountDestination { get; set; }

        public decimal TransferAmount { get; set; }
    }
}

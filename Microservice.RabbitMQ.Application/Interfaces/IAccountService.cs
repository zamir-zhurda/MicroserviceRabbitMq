using Microservice.RabbitMQ.Banking.Application.ViewModel;
using Microservice.RabbitMQ.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.RabbitMQ.Banking.Application.Interfaces
{
   public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void TransferFunds(AccountTransfer accountTransfer);
    }
}

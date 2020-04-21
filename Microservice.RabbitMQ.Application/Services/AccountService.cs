using Microservice.RabbitMQ.Banking.Application.Interfaces;
using Microservice.RabbitMQ.Banking.Application.ViewModel;
using Microservice.RabbitMQ.Banking.Domain.Commands;
using Microservice.RabbitMQ.Banking.Domain.Interfaces;
using Microservice.RabbitMQ.Banking.Domain.Models;
using Microservice.RabbitMQ.Domain.Core.Bus;
using System.Collections.Generic;

namespace Microservice.RabbitMQ.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _eventBus;

        public AccountService(IAccountRepository accountRepository, IEventBus eventBus)
        {
            _accountRepository = accountRepository;
            _eventBus = eventBus;
        }
        public IEnumerable<Account> GetAccounts()
        {
          return  _accountRepository.GetAccounts();
        }

        public void TransferFunds(AccountTransfer accountTransfer)
        {
            CreateTransferCommand transferCommand = new CreateTransferCommand(accountTransfer.FromAccountSource, accountTransfer.ToAccountDestination, accountTransfer.TransferAmount);

            //let's send the command
            _eventBus.SendCommand(transferCommand);
        }



    }
}

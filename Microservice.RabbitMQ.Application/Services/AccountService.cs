using Microservice.RabbitMQ.Banking.Application.Interfaces;
using Microservice.RabbitMQ.Banking.Domain.Interfaces;
using Microservice.RabbitMQ.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.RabbitMQ.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IEnumerable<Account> GetAccounts()
        {
          return  _accountRepository.GetAccounts();
        }
    }
}

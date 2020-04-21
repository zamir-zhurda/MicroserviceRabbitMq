using Microservice.RabbitMQ.Banking.Data.DbContext;
using Microservice.RabbitMQ.Banking.Domain.Interfaces;
using Microservice.RabbitMQ.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microservice.RabbitMQ.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private BankingDbContext _bankingDbContext;
        public AccountRepository(BankingDbContext bankingDbContext)
        {
            _bankingDbContext = bankingDbContext;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _bankingDbContext.Accounts.ToList();
        }
    }
}

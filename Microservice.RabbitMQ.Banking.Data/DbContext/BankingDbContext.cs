using System;
using System.Collections.Generic;
using System.Text;
using Microservice.RabbitMQ.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservice.RabbitMQ.Banking.Data.DbContext
{
    public class BankingDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public BankingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
    }
}

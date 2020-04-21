using System;
using System.Collections.Generic;
using System.Text;
using Microservice.RabbitMQ.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservice.RabbitMQ.Transfer.Data.DbContext
{
    public class TransferDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public TransferDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}

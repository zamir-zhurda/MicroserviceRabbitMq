using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.RabbitMQ.Banking.Domain.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountType { get; set; }

        public decimal AccountBalance { get; set; }
    }
}

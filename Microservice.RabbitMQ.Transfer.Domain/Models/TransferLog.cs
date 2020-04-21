﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.RabbitMQ.Transfer.Domain.Models
{
    public class TransferLog
    {
        public int Id { get; set; }
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }

        public decimal TransferAmount { get; set; }
    }
}

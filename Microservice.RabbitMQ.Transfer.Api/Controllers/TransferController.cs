using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.RabbitMQ.Transfer.Application.Interfaces;
using Microservice.RabbitMQ.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Microservice.RabbitMQ.Transfer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        private readonly ILogger<TransferController> _logger;

        public TransferController(ITransferService transferService, ILogger<TransferController> logger)
        {
            _transferService = transferService;
            _logger = logger;
        }

        //GET api/transfer
        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}

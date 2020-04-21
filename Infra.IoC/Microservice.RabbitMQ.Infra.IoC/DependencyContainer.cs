using Microsoft.Extensions.DependencyInjection;
using Microservice.RabbitMQ.Domain.Core.Bus;
using Microservice.RabbitMQ.Infra.Bus;
using Microservice.RabbitMQ.Banking.Application.Interfaces;
using Microservice.RabbitMQ.Banking.Application.Services;
using Microservice.RabbitMQ.Banking.Domain.Interfaces;
using Microservice.RabbitMQ.Banking.Data.Repository;
using Microservice.RabbitMQ.Banking.Data.DbContext;

namespace Microservice.RabbitMQ.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
        }
    }
}
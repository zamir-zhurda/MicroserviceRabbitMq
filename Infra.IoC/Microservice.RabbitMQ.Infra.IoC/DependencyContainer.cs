using Microsoft.Extensions.DependencyInjection;
using Microservice.RabbitMQ.Domain.Core.Bus;
using Microservice.RabbitMQ.Infra.Bus;
using Microservice.RabbitMQ.Banking.Application.Interfaces;
using Microservice.RabbitMQ.Banking.Application.Services;
using Microservice.RabbitMQ.Banking.Domain.Interfaces;
using Microservice.RabbitMQ.Banking.Data.Repository;
using Microservice.RabbitMQ.Banking.Data.DbContext;
using MediatR;
using Microservice.RabbitMQ.Banking.Domain.Commands;
using Microservice.RabbitMQ.Banking.Domain.CommandHandlers;
using Microservice.RabbitMQ.Transfer.Application.Services;
using Microservice.RabbitMQ.Transfer.Application.Interfaces;
using Microservice.RabbitMQ.Transfer.Data.Repository;
using Microservice.RabbitMQ.Transfer.Domain.Interfaces;
using Microservice.RabbitMQ.Transfer.Data.DbContext;
using Microservice.RabbitMQ.Transfer.Domain.EventHandlers;
using Microservice.RabbitMQ.Transfer.Domain.Events;

namespace Microservice.RabbitMQ.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            ///creating only one Instance!
            services.AddSingleton<IEventBus, RabbitMQBus>(serviceProviderOptions => {

                var scopeFactory = serviceProviderOptions.GetService<IServiceScopeFactory>();

                RabbitMQBus rabbitMQBus = new RabbitMQBus(serviceProviderOptions.GetService<IMediator>(), scopeFactory);

                return rabbitMQBus;

            });

            //Subscriptions
            services.AddTransient<TransferEventHandler>();

            //Add Domain Events (Banking + Transfer)
            services.AddTransient<IEventHandler<TransferCreatedEvents>, TransferEventHandler>();

            //Add Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand,bool>, TransferCommandHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();

            //DbContext
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using Microservice.RabbitMQ.Domain.Core.Bus;
using Microservice.RabbitMQ.Infra.Bus;

namespace Microservice.RabbitMQ.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}
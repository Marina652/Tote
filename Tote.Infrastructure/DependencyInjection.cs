using Microsoft.Extensions.DependencyInjection;
using Tote.Application.Event.Interfaces;
using Tote.Infrastructure.Repositories.Event;

namespace Tote.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IEventReader, EventReadRepository>();

            return services;
        }
    }
}

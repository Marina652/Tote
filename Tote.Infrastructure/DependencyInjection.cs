using Microsoft.Extensions.DependencyInjection;
using Tote.Application.Event.Interfaces;
using Tote.Infrastructure.Repositories.Event;

namespace Tote.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IEventReader, EventReadRepository>(provider => new EventReadRepository(connectionString));
            services.AddTransient<IEventRemover, EventRemoveRepository>(provider => new EventRemoveRepository(connectionString));
            services.AddTransient<IEventWriter, EventCreateRepository>(provider => new EventCreateRepository(connectionString));
            services.AddTransient<IEventUpdater, EventUpdateRepository>(provider => new EventUpdateRepository(connectionString));

            return services;
        }
    }
}

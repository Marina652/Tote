using Microsoft.Extensions.DependencyInjection;
using Tote.Application.Event.Interfaces;
using Tote.Application.SportType.Interfaces;
using Tote.Infrastructure.Repositories.Event;
using Tote.Infrastructure.Repositories.SportType;

namespace Tote.Infrastructure
{
    public static class DependencyInjections
    {
        //public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfifuration confifuration, string connectionString)
        //{
        //    var dbTotalConnectionSrtring = new DBTotalConnectionstring()
        //    {
        //        Value = confifuration.GetConnectionString();
        //    }

        //    services.Configure(dbTotalConnectionSrtring);
        //    services.AddTransient<IEventReader, EventReadRepository>(provider => new EventReadRepository(connectionString));
        //    services.AddTransient<IEventRemover, EventRemoveRepository>(provider => new EventRemoveRepository(connectionString));
        //    services.AddTransient<IEventWriter, EventCreateRepository>(provider => new EventCreateRepository(connectionString));
        //    services.AddTransient<IEventUpdater, EventUpdateRepository>(provider => new EventUpdateRepository(connectionString));

        //    services.AddTransient<ISportTypeReader, SportTypeReadRepository>(provider => new SportTypeReadRepository(connectionString));
        //    services.AddTransient<ISportTypeRemover, SportTypeRemoveRepository>(provider => new SportTypeRemoveRepository(connectionString));

        //    return services;
        //}

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IEventReader, EventReadRepository>(provider => new EventReadRepository(connectionString));
            services.AddTransient<IEventWriter, EventWriteRepository>(provider => new EventWriteRepository(connectionString));

            services.AddTransient<ISportTypeReader, SportTypeReadRepository>(provider => new SportTypeReadRepository(connectionString));
            services.AddTransient<ISportTypeRemover, SportTypeRemoveRepository>(provider => new SportTypeRemoveRepository(connectionString));

            return services;
        }
}
}

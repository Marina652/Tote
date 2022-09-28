using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using Tote.Application.Event.Interfaces;
using Tote.Application.SportType.Interfaces;
using Tote.Infrastructure.Repositories.Event;
using Tote.Infrastructure.Repositories.SportType;

namespace Tote.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string dbConnectionString = configuration.GetConnectionString("ConnectionString");
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString));

            services.AddTransient<IEventReader, EventReadRepository>();
            services.AddTransient<IEventWriter, EventWriteRepository>();

            services.AddTransient<ISportTypeReader, SportTypeReadRepository>();
            services.AddTransient<ISportTypeWriter, SportTypeWriteRepository>();

            return services;
        }
}
}

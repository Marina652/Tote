using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using Tote.Application.Event.Common.Interfaces;
using Tote.Application.OutcomeBlock.Common.Interfaces;
using Tote.Application.SportType.Common.Interfaces;
using Tote.Infrastructure.Repositories.Event;
using Tote.Infrastructure.Repositories.OutcomeBlock;
using Tote.Infrastructure.Repositories.SportType;

namespace Tote.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbConnectionFactory(configuration);

            services.AddTransient<IEventReader, EventReadRepository>();
            services.AddTransient<IEventWriter, EventWriteRepository>();

            services.AddTransient<ISportTypeReader, SportTypeReadRepository>();
            services.AddTransient<ISportTypeWriter, SportTypeWriteRepository>();

            services.AddTransient<IOutcomeBlockReader, OutcomeBlockReadRepository>();
            services.AddTransient<IOutcomeBlockWriter, OutcomeBlockWriteRepository>();

            return services;
        }

        static IServiceCollection AddDbConnectionFactory(this IServiceCollection services, IConfiguration configuration)
        {
            string dbConnectionString = configuration.GetConnectionString("ToteDb");
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString));
            return services;
        }
    }
}

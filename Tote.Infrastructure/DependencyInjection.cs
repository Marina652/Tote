using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using Tote.Application.Event.Common.Interfaces;
using Tote.Application.Market.Common.Interfaces;
using Tote.Application.OutcomeBlock.Common.Interfaces;
using Tote.Application.SportType.Common.Interfaces;
using Tote.Infrastructure.Repositories.Event;
using Tote.Infrastructure.Repositories.Event.SportType;
using Tote.Infrastructure.Repositories.OutcomeBlock;
using Tote.Infrastructure.Repositories.OutcomeBlock.Market;

namespace Tote.Infrastructure;

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

        services.AddTransient<IMarketReader, MarketReadRepository>();
        services.AddTransient<IMarketWriter, MarketWriteRepository>();

        return services;
    }

    static IServiceCollection AddDbConnectionFactory(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CustomConnectionStrings>(options => configuration.GetSection(nameof(CustomConnectionStrings)).Bind(options));

        services.AddTransient<IConnectionFactory, ConnectionFactory>();

        return services;
    }
}

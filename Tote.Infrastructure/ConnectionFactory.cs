using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Tote.Infrastructure;

internal class ConnectionFactory : IConnectionFactory
{
    private readonly IOptions<CustomConnectionStrings> _options;

    public ConnectionFactory(IOptions<CustomConnectionStrings> options)
    {
        _options = options;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _options.Value.ToteDbConnecion;

        if (connectionString is null) 
            return null;

        return new SqlConnection(connectionString);
    }
}

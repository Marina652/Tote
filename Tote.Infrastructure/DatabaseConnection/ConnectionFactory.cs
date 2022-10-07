using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Tote.Infrastructure.DatabaseConnection;

internal class ConnectionFactory : IConnectionFactory
{
    private readonly CustomConnectionStrings _options;

    public ConnectionFactory(IOptions<CustomConnectionStrings> options)
    {
        _options = options.Value;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _options.ToteDbConnecion;

        if (connectionString is null)
            return null;

        return new SqlConnection(connectionString);
    }
}

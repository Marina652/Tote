using System.Data;

namespace Tote.Infrastructure.DatabaseConnection;

internal interface IConnectionFactory
{
    internal IDbConnection CreateConnection();
}

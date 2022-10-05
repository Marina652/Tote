using System.Data;

namespace Tote.Infrastructure;

internal interface IConnectionFactory
{
    internal IDbConnection CreateConnection();
}

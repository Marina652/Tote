using System.Data;

namespace Tote.Infrastructure.DatabaseConnection;

internal interface IConnectionFactory/*<T> where T : IDbConnection */
{
    //internal T CreateConnection();

    internal IDbConnection CreateConnection();
}

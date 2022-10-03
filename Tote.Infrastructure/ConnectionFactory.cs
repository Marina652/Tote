using System.Data.Common;
using System.Data.SqlClient;

namespace Tote.Infrastructure;

internal class ConnectionFactory
{
    public static DbConnection CreateDbConnection(string connectionString)
    {
        DbConnection connection;

        if (connectionString == null) return null;

        try
        {
            connection = new SqlConnection(connectionString);
        }

        catch (Exception ex)
        {
            connection = null;
        }

        return connection;
    }
}

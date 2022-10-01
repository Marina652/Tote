using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Tote.Infrastructure
{
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
}

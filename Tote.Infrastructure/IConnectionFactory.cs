using Microsoft.Extensions.Options;
using System.Data;
using System.Data.Common;

namespace Tote.Infrastructure;

internal interface IConnectionFactory
{
    internal IDbConnection CreateConnection();
}

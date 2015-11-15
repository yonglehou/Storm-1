using System;
using System.Configuration;

namespace Flyingpie.Storm.Dapper
{
    public class DapperConfiguration
    {
        public string ConnectionString { get; set; }

        public string ConnectionStringName { get; set; }

        public string GetConnectionString()
        {
            var hasConnectionString = !string.IsNullOrEmpty(ConnectionString);
            var hasConnectionStringName = !string.IsNullOrEmpty(ConnectionStringName);

            if ((!hasConnectionString && !hasConnectionStringName) || (hasConnectionString && hasConnectionStringName))
                throw new InvalidOperationException("Either a connection string or a connection string name must be specified.");

            if (hasConnectionString)
                return ConnectionString;

            var connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            if (connectionString == null)
                throw new InvalidOperationException("No connection string found with name '" + ConnectionStringName + "'.");

            return connectionString.ConnectionString;
        }
    }
}
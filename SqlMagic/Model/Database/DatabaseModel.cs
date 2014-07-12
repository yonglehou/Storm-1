using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SqlMagic.Model.Database
{
    public class DatabaseModel
    {
        public List<SchemaInfo> Schemas { get; private set; }
        public List<StoredProcedureInfo> StoredProcedures { get; private set; }
        public List<ParameterInfo> Parameters { get; private set; }
        public List<UserDefinedTypeInfo> UserDefinedTypes { get; private set; }
        public List<UserDefinedTypeColumnInfo> UserDefinedTypeColumns { get; private set; }

        private string _connectionString;

        public DatabaseModel(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Initialize()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                Schemas = connection.Query<SchemaInfo>(Resources.Sql.ListSchemas);
                StoredProcedures = connection.Query<StoredProcedureInfo>(Resources.Sql.ListStoredProcedures);
                UserDefinedTypes = connection.Query<UserDefinedTypeInfo>(Resources.Sql.ListUserDefinedTypes);
                UserDefinedTypeColumns = connection.Query<UserDefinedTypeColumnInfo>(Resources.Sql.ListUserDefinedTypeColumns);
                Parameters = connection.Query<ParameterInfo>(Resources.Sql.ListParameters);

                Schemas.ToList().ForEach(s => s.Initialize(this));
            }
        }
    }
}

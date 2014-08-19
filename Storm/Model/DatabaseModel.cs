﻿using Flyingpie.Storm.Converters;
using Flyingpie.Storm.Utility;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Flyingpie.Storm.Model
{
    public class DatabaseModel
    {
        // Maybe put these in a seperate class
        public string RootNamespace
        {
            get { return GeneratorConfiguration.Instance.RootNamespace; }
            set { /* Required for serialization */ }
        }

        public string LibraryName
        {
            get { return GeneratorConfiguration.Instance.LibraryName; }
            set { /* Required for serialization */ }
        }

        public string LibraryVersion
        {
            get { return GeneratorConfiguration.Instance.LibraryVersion; }
            set { /* Required for serialization */ }
        }
        // Until here

        public List<SchemaInfo> Schemas { get; private set; }

        public List<StoredProcedureInfo> StoredProcedures { get; private set; }

        public List<ParameterInfo> Parameters { get; private set; }

        public List<UserDefinedTypeInfo> UserDefinedTypes { get; private set; }

        public List<UserDefinedTypeColumnInfo> UserDefinedTypeColumns { get; private set; }

        private string _connectionString;

        public DatabaseModel()
        {
        }

        public DatabaseModel(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Initialize()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                Schemas = connection.Query<SchemaInfo>(Flyingpie.Storm.Resources.Sql.ListSchemas);
                StoredProcedures = connection.Query<StoredProcedureInfo>(Flyingpie.Storm.Resources.Sql.ListStoredProcedures);
                UserDefinedTypes = connection.Query<UserDefinedTypeInfo>(Flyingpie.Storm.Resources.Sql.ListUserDefinedTypes);
                UserDefinedTypeColumns = connection.Query<UserDefinedTypeColumnInfo>(Flyingpie.Storm.Resources.Sql.ListUserDefinedTypeColumns);
                Parameters = connection.Query<ParameterInfo>(Flyingpie.Storm.Resources.Sql.ListParameters);

                Schemas.ToList().ForEach(s => s.Initialize(this));
            }
        }
    }
}
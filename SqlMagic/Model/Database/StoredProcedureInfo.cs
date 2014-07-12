using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SqlMagic.Model.Database
{
    public class StoredProcedureInfo
    {
        [MapTo("StoredProcedureName")]
        public string Name { get; private set; }

        [MapTo("SchemaName")]
        public string SchemaName { get; private set; }

        public SchemaInfo Schema { get; private set; }
        public List<ParameterInfo> Parameters { get; private set; }

        internal void Initialize(SchemaInfo schema)
        {
            Schema = schema;
            Parameters = schema.Database.Parameters.Where(p => p.StoredProcedureName == Name).ToList();
            Parameters.ForEach(p => p.Initialize(this));
        }

        public override string ToString()
        {
            return SchemaName + "." + Name;
        }
    }
}

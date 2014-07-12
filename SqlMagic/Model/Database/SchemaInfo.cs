using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SqlMagic.Model.Database
{
    public class SchemaInfo
    {
        [MapTo("SchemaId")]
        public int Id { get; private set; }

        [MapTo("SchemaName")]
        public string Name { get; private set; }

        public List<StoredProcedureInfo> StoredProcedures { get; private set; }
        public List<UserDefinedTypeInfo> UserDefinedTypes { get; private set; }

        public DatabaseModel Database { get; private set; }

        internal void Initialize(DatabaseModel database)
        {
            Database = database;

            StoredProcedures = database.StoredProcedures.Where(sp => sp.SchemaName == Name).ToList();
            StoredProcedures.ForEach(sp => sp.Initialize(this));

            UserDefinedTypes = database.UserDefinedTypes.Where(sp => sp.SchemaName == Name).ToList();
            UserDefinedTypes.ForEach(udt => udt.Initialize(this));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

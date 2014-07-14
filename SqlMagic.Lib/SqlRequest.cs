using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Lib
{
    public class SqlRequest
    {
        public string SchemaName { get; set; }
        public string StoredProcedureName { get; set; }
        public List<StoredProcedureParameter> Parameters { get; set; }

        public SqlRequest(string schemaName, string storedProcedureName)
        {
            SchemaName = schemaName;
            StoredProcedureName = storedProcedureName;
            Parameters = new List<StoredProcedureParameter>();
        }
    }

    public abstract class StoredProcedureParameter
    {
        public string Name { get; set; }
    }

    public class StoredProcedureSimpleParameter : StoredProcedureParameter
    {
        public StoredProcedureSimpleParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public object Value { get; set; }

        public override string ToString()
        {
            return Name + "(" + Value + ")";
        }
    }

    public class StoredProcedureTableTypeParameter : StoredProcedureParameter
    {
        public StoredProcedureTableTypeParameter(string name, string schemaName, string udtName, IEnumerable table)
        {
            Name = name;
            SchemaName = schemaName;
            UdtName = udtName;
            Table = table;
        }

        public string SchemaName { get; set; }
        public string UdtName { get; set; }
        public IEnumerable Table { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

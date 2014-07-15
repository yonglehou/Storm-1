using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Flyingpie.Storm.Executors
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

        public object GetParameterValue(string name)
        {
            var parameter = Parameters.SingleOrDefault(p => p.Name == name);
            if (parameter == null)
            {
                throw new InvalidOperationException("No such parameter with name '" + name + "'");
            }

            return parameter.GetValueAsObject();
        }
    }

    public abstract class StoredProcedureParameter
    {
        public string Name { get; set; }

        public ParameterDirection Mode { get; set; }

        public string DirectionString { get; set; }

        public abstract object GetValueAsObject();
    }

    public class StoredProcedureSimpleParameter : StoredProcedureParameter
    {
        public StoredProcedureSimpleParameter(string name, ParameterDirection mode, object value)
        {
            Name = name;
            Mode = mode;
            Value = value;
        }

        public object Value { get; set; }

        public override object GetValueAsObject()
        {
            return Value;
        }

        public override string ToString()
        {
            return Name + "(" + Value + ")";
        }
    }

    public class StoredProcedureTableTypeParameter : StoredProcedureParameter
    {
        public StoredProcedureTableTypeParameter(string name, ParameterDirection mode, string udtSchemaName, string udtName, IEnumerable table)
        {
            Name = name;
            Mode = mode;
            SchemaName = udtSchemaName;
            UdtName = udtName;
            Table = table;
        }

        public string SchemaName { get; set; }

        public string UdtName { get; set; }

        public IEnumerable Table { get; set; }

        public override object GetValueAsObject()
        {
            return Table;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
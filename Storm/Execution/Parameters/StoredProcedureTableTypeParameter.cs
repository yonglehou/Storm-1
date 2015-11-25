using System.Collections;
using System.Data;

namespace Flyingpie.Storm.Execution.Parameters
{
    public class StoredProcedureTableTypeParameter : StoredProcedureParameter
    {
        public StoredProcedureTableTypeParameter(string name, string typeName, ParameterDirection mode, string udtSchemaName, string udtName, IEnumerable table)
        {
            Name = name;
            TypeName = typeName;
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

        public override void SetValueAsObject(object value)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
using System.Data;

namespace Flyingpie.Storm.Execution.Parameters
{
    public class StoredProcedureSimpleParameter : StoredProcedureParameter
    {
        public StoredProcedureSimpleParameter(string name, string typeName, ParameterDirection mode, object value)
        {
            Name = name;
            TypeName = typeName;
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
}
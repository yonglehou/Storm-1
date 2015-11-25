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
            var outputParameter = Value as IOutputParameter;
            if (outputParameter != null) return outputParameter.GetValueAsObject();

            return Value;
        }

        public override void SetValueAsObject(object value)
        {
            var outputParameter = Value as IOutputParameter;
            if (outputParameter != null) outputParameter.SetValueAsObject(value);
            else Value = value;
        }

        public override string ToString()
        {
            return Name + "(" + Value + ")";
        }
    }
}
namespace Flyingpie.Storm.Execution.Parameters
{
    public class OutputParameter<T> : IOutputParameter
    {
        public T Value { get; set; }

        public OutputParameter(T value)
        {
            Value = value;
        }

        public OutputParameter()
        {
        }

        public object GetValueAsObject()
        {
            return Value;
        }

        public void SetValueAsObject(object value)
        {
            Value = (T)value;
        }
    }

    public interface IOutputParameter
    {
        object GetValueAsObject();

        void SetValueAsObject(object value);
    }
}
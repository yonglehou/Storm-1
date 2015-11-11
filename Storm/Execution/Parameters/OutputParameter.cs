namespace Flyingpie.Storm.Execution.Parameters
{
    public class OutputParameter<T>
    {
        public T Value { get; set; }

        public OutputParameter(T value)
        {
            Value = value;
        }

        public OutputParameter()
        {
        }
    }
}
using Flyingpie.Storm.Execution.Parameters;

namespace Flyingpie.Storm
{
    public static class Extensions
    {
        public static OutputParameter<T> AsOutputParameter<T>(this T source)
        {
            return new OutputParameter<T>(source);
        }
    }
}
using Flyingpie.Storm.Executors;

namespace Flyingpie.Storm
{
    public interface IQueryChain
    {
        void Use(IMiddleWare middleWare);

        T Execute<T>(SqlRequest request) where T : SqlResponse;
    }
}
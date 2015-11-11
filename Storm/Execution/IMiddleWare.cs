using System;

namespace Flyingpie.Storm.Execution
{
    public interface IMiddleware
    {
        Func<ISqlRequest, ISqlExecutor> Execute(Func<ISqlRequest, ISqlExecutor> next);
    }
}
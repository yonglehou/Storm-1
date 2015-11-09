using System;

namespace Flyingpie.Storm.Executors
{
    public interface IMiddleWare
    {
        Func<SqlRequest, T> Execute<T>(Func<SqlRequest, T> next) where T : SqlResponse;
    }
}
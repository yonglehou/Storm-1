using System;
using System.Collections.Generic;
using System.Data;

namespace Flyingpie.Storm.Executors
{
    public interface ISqlExecutor
    {
        T Execute<T>(SqlRequest request) where T : SqlResponse;

        IDbTransaction BeginTransaction();

        int Query(SqlRequest request);

        IEnumerable<T> Query<T>(SqlRequest request);

        Tuple<IEnumerable<T1>, IEnumerable<T2>> Query<T1, T2>(SqlRequest request);

        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> Query<T1, T2, T3>(SqlRequest request);
    }
}
using System;
using System.Collections.Generic;
using System.Data;

namespace Flyingpie.Storm.Executors
{
    public interface ISqlExecutor : IDisposable
    {
        T Execute<T>(SqlRequest request) where T : SqlResponse;

        IDbTransaction BeginTransaction();

        int Query(SqlRequest request);

        IEnumerable<T> Query<T>(SqlRequest request);

        Tuple<IEnumerable<T1>, IEnumerable<T2>> Query<T1, T2>(SqlRequest request);

        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> Query<T1, T2, T3>(SqlRequest request);

        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>> Query<T1, T2, T3, T4>(SqlRequest request);

        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>> Query<T1, T2, T3, T4, T5>(SqlRequest request);

        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>> Query<T1, T2, T3, T4, T5, T6>(SqlRequest request);

        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>> Query<T1, T2, T3, T4, T5, T6, T7>(SqlRequest request);
    }
}
using System;
using System.Collections.Generic;
using System.Data;

namespace Flyingpie.Storm.Execution
{
    public interface ISqlExecutor : IDisposable
    {
        IDbTransaction BeginTransaction();

        void NonQuery(ISqlRequest request);

        T Scalar<T>(ISqlRequest request);

        IEnumerable<T> Query<T>(ISqlRequest request);

        IMultipleResultSetReader Multiple(ISqlRequest request);
    }
}
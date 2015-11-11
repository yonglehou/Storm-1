using Flyingpie.Storm.Execution.Parameters;
using System.Collections.Generic;

namespace Flyingpie.Storm.Execution
{
    public interface ISqlRequest
    {
        IQueryChain QueryChain { get; }

        string SchemaName { get; }

        string StoredProcedureName { get; }

        List<StoredProcedureParameter> Parameters { get; }

        object GetParameterValue(string name);

        void NonQuery();

        T Scalar<T>();

        IEnumerable<T> Query<T>();

        IMultipleResultSetReader Multiple();
    }
}
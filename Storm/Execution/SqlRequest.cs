using Flyingpie.Storm.Execution.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flyingpie.Storm.Execution
{
    public class SqlRequest : ISqlRequest
    {
        public IQueryChain QueryChain { get; set; }

        public string SchemaName { get; set; }

        public string StoredProcedureName { get; set; }

        public List<StoredProcedureParameter> Parameters { get; set; }

        public SqlRequest(IQueryChain queryChain, string schemaName, string storedProcedureName)
        {
            QueryChain = queryChain;
            SchemaName = schemaName;
            StoredProcedureName = storedProcedureName;
            Parameters = new List<StoredProcedureParameter>();
        }

        public object GetParameterValue(string name)
        {
            var parameter = Parameters.SingleOrDefault(p => p.Name == name);
            if (parameter == null)
            {
                throw new InvalidOperationException("No such parameter with name '" + name + "'");
            }

            return parameter.GetValueAsObject();
        }

        public void NonQuery()
        {
            var executor = QueryChain.CreateExecutor(this);

            executor.NonQuery(this);
        }

        public T Scalar<T>()
        {
            var executor = QueryChain.CreateExecutor(this);

            return executor.Scalar<T>(this);
        }

        public int ScalarInt()
        {
            return Scalar<int>();
        }

        public IEnumerable<T> Query<T>()
        {
            var executor = QueryChain.CreateExecutor(this);

            return executor.Query<T>(this);
        }

        public IMultipleResultSetReader Multiple()
        {
            var executor = QueryChain.CreateExecutor(this);

            return executor.Multiple(this);
        }
    }
}
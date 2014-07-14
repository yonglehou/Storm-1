using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Lib
{
    public class SqlResponse
    {
        public virtual void Execute(SqlRequest request, ISqlExecutor executor)
        {
            executor.Query(request);
        }
    }

    public class SqlResponse<T> : SqlResponse
    {
        public IEnumerable<T> Items { get; set; }

        public override void Execute(SqlRequest request, ISqlExecutor executor)
        {
            Items = executor.Query<T>(request);
        }
    }

    public class SqlResponse<T1, T2> : SqlResponse
    {
        public IEnumerable<T1> Items1 { get; set; }
        public IEnumerable<T2> Items2 { get; set; }

        public override void Execute(SqlRequest request, ISqlExecutor executor)
        {
            var result = executor.Query<T1, T2>(request);

            Items1 = result.Item1;
            Items2 = result.Item2;
        }
    }

    public class SqlResponse<T1, T2, T3> : SqlResponse
    {
        public IEnumerable<T1> Items1 { get; set; }
        public IEnumerable<T2> Items2 { get; set; }
        public IEnumerable<T3> Items3 { get; set; }

        public override void Execute(SqlRequest request, ISqlExecutor executor)
        {
            var result = executor.Query<T1, T2, T3>(request);

            Items1 = result.Item1;
            Items2 = result.Item2;
            Items3 = result.Item3;
        }
    }
}
